using cityGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace cityGuide.Data
{
    public class Context: DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<City> City { get; set; }
    }
}