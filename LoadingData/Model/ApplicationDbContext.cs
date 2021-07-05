using Microsoft.EntityFrameworkCore;

namespace LoadData.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
