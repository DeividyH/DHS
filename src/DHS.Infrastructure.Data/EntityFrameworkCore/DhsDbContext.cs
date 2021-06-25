using DHS.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DHS.Infrastructure.Data.EntityFrameworkCore
{
    public class DhsDbContext : DbContext
    {
        public DhsDbContext(DbContextOptions<DhsDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(false);
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .Property(b => b.CreatorUserId)
            //    .IsRequired();
        }
        #endregion
    }
}
