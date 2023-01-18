using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Auth> AuthItems { get; set; }
    }
}
