using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BELTEXAM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BELTEXAM.Controllers {
    public class HomeController : Controller {
        private MyContext dbContext;
        public HomeController (MyContext context) {
            dbContext = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpGet ("register")]
        public IActionResult LoginReg () {
            return RedirectToAction ("Index");
        }

        [HttpGet ("login")]
        public IActionResult RegLogin () {
            return RedirectToAction ("Index");
        }

        [HttpPost ("register")]
        public IActionResult Register (User newUser) {
            Regex rx = new Regex (@"\d");
            if (newUser.FirstName != null) {
                MatchCollection FirstNameMatches = rx.Matches (newUser.FirstName);
                if (FirstNameMatches.Count != 0) {
                    ModelState.AddModelError ("FirstName", "First Name Fields cannot contain numeric characters");
                }
            }
            if (newUser.LastName != null) {
                MatchCollection LastNameMatches = rx.Matches (newUser.LastName);
                if (LastNameMatches.Count != 0) {
                    ModelState.AddModelError ("LastName", " Last Name Fields cannot contain numeric characters");
                }
            }
            if (newUser.Password != null) {
                MatchCollection PasswordNumberMatches = rx.Matches (newUser.Password);
                if (PasswordNumberMatches.Count == 0) {
                    ModelState.AddModelError ("Password", "Password should contain at least one number");
                }
                string SpecialChars = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                bool HasSpecialChars = false;
                foreach (var character in SpecialChars) {
                    if (newUser.Password.Contains (character)) {
                        HasSpecialChars = true;
                    }
                }
                if (!HasSpecialChars) {
                    ModelState.AddModelError ("Password", "Password should contain at least one special character");
                }
            }
            if (dbContext.Users.Any (c => c.Email == newUser.Email)) {
                ModelState.AddModelError ("Email", "That Email is taken");
            }
            if (ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                newUser.Password = Hasher.HashPassword (newUser, newUser.Password);
                HttpContext.Session.SetString ("UserName", newUser.FirstName + " " + newUser.LastName);
                dbContext.Users.Add (newUser);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("ID", newUser.ID);
                return Redirect ("home");
            }
            return View ("Index");
        }

        [HttpPost ("login")]
        public IActionResult Login (Login _logUSer) {
            User DbUser = dbContext.Users.FirstOrDefault (c => c.Email == _logUSer.LoginEmail);
            if (DbUser == null) {
                ModelState.AddModelError ("LoginEmail", "Email not found. Register?");
            }
            if (ModelState.IsValid) {
                var hasher = new PasswordHasher<Login> ();
                var result = hasher.VerifyHashedPassword (_logUSer, DbUser.Password, _logUSer.LoginPassword);
                if (result == 0) {
                    ModelState.AddModelError ("LoginEmail", "Email or password not valid");
                    return View ("Index");
                }
                HttpContext.Session.SetInt32 ("ID", DbUser.ID);
                HttpContext.Session.SetString ("UserName", DbUser.FirstName + " " + DbUser.LastName);
                return Redirect ("home");
            }
            return View ("Index");
        }

        [HttpGet ("logout")]
        public IActionResult LogOut () {
            HttpContext.Session.Clear ();
            return Redirect ("/");
        }

        [HttpGet ("home")]
        public IActionResult Home () {
            if (HttpContext.Session.GetInt32 ("ID") == null) {
                return Redirect ("/");
            }
            List<Event> Events = dbContext.Events
                .Include (u => u.Participants)
                .ThenInclude (u => u.User)
                .Include (e => e.Coordinator)
                .ToList ();
            ViewBag.Events = Events;
            int? seshUser = HttpContext.Session.GetInt32 ("ID");

            List<Participant> yourEvents = dbContext.Participants
                .Where (p => p.UserID == (int) seshUser)
                .Include (p => p.Event)
                .ToList ();
            ViewBag.EventsWithConflicts = yourEvents;

            List<User> AllUsers = dbContext.Users.ToList ();
            int UserID = (int) HttpContext.Session.GetInt32 ("ID");
            User SignedIn = dbContext.Users.FirstOrDefault (u => u.ID == UserID);

            return View ("Home", SignedIn);
        }

        [HttpGet ("newevent")]
        public IActionResult NewEventForm () {
            if (HttpContext.Session.GetInt32 ("ID") == null) {
                return Redirect ("/");
            }
            HttpContext.Session.SetString ("Page", "newForm");
            return View ();
        }

        [HttpPost ("newevent")]
        public IActionResult NewEvent (Event newEvent) {
            if (newEvent.DateOfEvent != null) {
                DateTime Now = (DateTime) newEvent.DateOfEvent;
                if (Now.Date < DateTime.Today.Date) {
                    ModelState.AddModelError ("DateOfEvent", "Please input a future date for your event.");
                }
            }

            if (ModelState.IsValid) {
                int? seshUser = HttpContext.Session.GetInt32 ("ID");
                User EventCreator = dbContext.Users.FirstOrDefault (u => u.ID == seshUser);
                newEvent.Coordinator = EventCreator;
                newEvent.CoordinatorID = (int) seshUser;
                dbContext.Events.Add (newEvent);
                dbContext.SaveChanges ();
                return Redirect ($"activity/{newEvent.ID}");
            }
            return View ("NewEventForm");
        }

        [HttpGet ("activity/{eventID}")]
        public IActionResult ViewEvent (int eventID) {
            if (HttpContext.Session.GetInt32 ("ID") == null) {
                return Redirect ("/");
            }
            HttpContext.Session.SetString ("Page", "View");
            Event thisEvent = dbContext.Events
                .Include (u => u.Participants)
                .ThenInclude (e => e.User)
                .Include (e => e.Coordinator)

                .FirstOrDefault (e => e.ID == eventID);
            return View (thisEvent);
        }

        [HttpGet ("delete/{eventID}")]
        public IActionResult DeleteEvent (int eventID) {
            Event thisEvent = dbContext.Events.FirstOrDefault (e => e.ID == eventID);
            dbContext.Events.Remove (thisEvent);
            dbContext.SaveChanges ();
            return Redirect ("/home");

        }

        [HttpGet ("Rsvp/{eventID}")]
        public IActionResult JoinEvent (int eventID) {

            int? seshUser = HttpContext.Session.GetInt32 ("ID");
            Event thisEvent = dbContext.Events.FirstOrDefault (e => e.ID == eventID);
            User thisUser = dbContext.Users.FirstOrDefault (u => u.ID == (int) seshUser);
            Participant newPart = new Participant ();

            List<Participant> yourEvents = dbContext.Participants
                .Where (p => p.UserID == (int) seshUser)
                .Include (p => p.Event)

                .ToList ();

            foreach (var part in yourEvents) {
                if (part.Event.DateOfEvent == thisEvent.DateOfEvent) {
                    TempData["Conflict"] = "You're already booked for that day!";
                    return Redirect ($"/activity/{eventID}");
                }
            }

            newPart.Event = thisEvent;
            newPart.User = thisUser;
            newPart.UserID = (int) seshUser;
            newPart.EventID = eventID;
            dbContext.Participants.Add (newPart);
            dbContext.SaveChanges ();
            return Redirect ("/home");
        }

        [HttpGet ("UnRsvp/{eventID}")]
        public IActionResult LeaveEvent (int eventID) {

            Event thisEvent = dbContext.Events.FirstOrDefault (e => e.ID == eventID);
            Participant thisPart;
            int? seshUser = HttpContext.Session.GetInt32 ("ID");
            List<Participant> thisParts = dbContext.Participants
                .Where (p => p.EventID == eventID).ToList ();
            foreach (var part in thisParts) {
                if (part.UserID == (int) seshUser) {
                    thisPart = part;
                    dbContext.Participants.Remove (thisPart);
                    dbContext.SaveChanges ();
                }
            }
            return Redirect ("/home");
        }
    }
}