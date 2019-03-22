using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BELTEXAM.Models {
    public class User {
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "First Name field required")]
        [MinLength (3, ErrorMessage = "Minimum length 3 characters")]
        [Display (Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name field required")]
        [MinLength (3, ErrorMessage = "Minimum length 3 characters")]
        [Display (Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Email Address field required")]
        [EmailAddress (ErrorMessage = "Please enter valid email")]
        [Display (Name = "Email Address: ")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password field required")]
        [MinLength (8, ErrorMessage = "Password length 8 characters")]
        [Display (Name = "Password: ")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required (ErrorMessage = "Please confirm your password")]
        [Compare ("Password", ErrorMessage = "Passwords do not match")]
        [DataType (DataType.Password)]
        [Display (Name = "Confirm Password: ")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Participant> Participants { get; set; }
    }
}