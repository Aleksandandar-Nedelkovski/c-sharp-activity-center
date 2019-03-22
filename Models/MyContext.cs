using Microsoft.EntityFrameworkCore;

namespace BELTEXAM.Models {
    public class MyContext : DbContext {
        public MyContext (DbContextOptions options) : base (options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}