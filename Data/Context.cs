using cityGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace cityGuide.Data
{
    public class Context: DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options):base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }


    }
}