using Microsoft.EntityFrameworkCore;
using WordMaster.Services.LanguageAPI.Models;

namespace WordMaster.Services.LanguageAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>().HasData(new Language()
            {
                Id = 1,
                Name = "English"
            });
            modelBuilder.Entity<Language>().HasData(new Language()
            {
                Id = 2,
                Name = "Russian"
            });
            modelBuilder.Entity<Language>().HasData(new Language()
            {
                Id = 3,
                Name = "France"
            });
            modelBuilder.Entity<Language>().HasData(new Language()
            {
                Id = 4,
                Name = "German"
            });
        }
    }
}
