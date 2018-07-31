using CtlgEver.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace CtlgEver.Infrastructure.Data
{
    public class CtlgEverContext : DbContext
    {
        public CtlgEverContext()
        {
  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Sheet> Sheets {get; set;}

        public CtlgEverContext (DbContextOptions<CtlgEverContext> options) : base (options) { }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User> ()
                .HasMany<Sheet> (s => s.Sheets)
                .WithOne (u => u.User)
                .HasForeignKey(s => s.SheetId);
        }
    }
}