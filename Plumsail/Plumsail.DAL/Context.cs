using Microsoft.EntityFrameworkCore;

namespace Plumsail.DAL
{
    public class Context : DbContext
    {
        public DbSet<Contact> Сontacts { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
