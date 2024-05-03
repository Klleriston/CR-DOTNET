using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class CrDB : DbContext
    {
        public CrDB(DbContextOptions options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}