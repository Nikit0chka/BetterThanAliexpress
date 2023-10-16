using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BetterThanAliexpress.EntityFramework;

public class DataBaseContext : DbContext
{
    public DbSet<Buyer>? Buyers;
    public DbSet<Seller>? Sellers;
    public DbSet<Product>? Products;
    public DbSet<ProductCategory>? Categories;
    
    public DataBaseContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BetterAliexpressDb;Trusted_Connection=True;");
}