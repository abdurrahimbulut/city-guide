using cityGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace cityGuide.Data
{
    public class Context: DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options):base(options)
        {
        }
        
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Comment>()
                .HasOne<City>(com => com.City)
                .WithMany(ci => ci.Comment)
                .HasForeignKey(com => com.CityId);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(com => com.User)
                .WithMany(u => u.Comment)
                .HasForeignKey(com => com.UserId);
        }
       */


    }
}