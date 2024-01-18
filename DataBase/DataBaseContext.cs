namespace DataBase;

using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext
{
    public DbSet<Buyer> Buyers { get; set; } = null!;
    public DbSet<Seller> Sellers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BetterThanAliexpress;Trusted_Connection=True;MultipleActiveResultSets=true;");
}
