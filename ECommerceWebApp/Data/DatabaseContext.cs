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
            SeedData.SeedDB(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<ShoppingCart>()
                .HasMany(s => s.CartItems)
                .WithOne(i => i.ShoppingCart)
                .HasForeignKey(i => i.ShoppingCartId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.ShoppingCart)
                .WithOne(s => s.Account)
                .HasForeignKey<ShoppingCart>(s => s.AccountId);
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Auth> AuthItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingItem> ShoppingItems { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
