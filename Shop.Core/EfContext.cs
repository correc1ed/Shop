using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace Shop.Core;
public class EfContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public EfContext() : base() { }
    public EfContext(DbContextOptions<EfContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Конфигурации сущностей
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=internetshopdb;Username=postgres;Password=1;");
    }
}
