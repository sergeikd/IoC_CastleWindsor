using System.Data.Entity;
using Oxagile.Internal.IoC.Entities;

namespace Oxagile.Internal.IoC.DALCF
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DbConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}