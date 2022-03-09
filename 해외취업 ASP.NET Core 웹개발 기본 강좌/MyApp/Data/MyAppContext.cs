using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : IdentityDbContext<ApplicationUser>
    {
        public MyAppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
