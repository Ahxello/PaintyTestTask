using Microsoft.EntityFrameworkCore;
using PaintyTestTask.Entities;

namespace PaintyTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
