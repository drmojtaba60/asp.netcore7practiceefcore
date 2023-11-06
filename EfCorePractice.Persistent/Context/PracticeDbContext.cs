using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Persistence
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

    }
}
