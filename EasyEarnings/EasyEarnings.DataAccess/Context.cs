using EasyEarnings.Models;
using System.Data.Entity;

namespace EasyEarnings.DataAccess
{
    public class Context: DbContext
    {
        public Context(): base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Counter> Counters { get; set; }
    }
}
