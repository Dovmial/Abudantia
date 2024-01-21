using Abudantia.Models;
using Microsoft.EntityFrameworkCore;

namespace Abudantia.Data
{
    public class EfContext: DbContext
    {
        public EfContext(DbContextOptions options) : base(options) 
            => Database.MigrateAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity(e => e.ToTable(nameof(OrdersProducts)));
            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
        #region DbSet
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<OrdersProducts> ListProductsForUser { get; set; } = null!;
        #endregion
    }
}
