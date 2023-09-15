using Microsoft.EntityFrameworkCore;
using StageTT.Entity;

namespace StageTT.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> person { get; set; }
    }
}
