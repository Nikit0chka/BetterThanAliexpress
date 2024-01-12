using Microsoft.EntityFrameworkCore;

namespace BetterThanAliexpress.EntityFramework;

public class DataBaseContext : DbContext
{
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BetterThanAliexpress;Trusted_Connection=True;MultipleActiveResultSets=true;");
}
