namespace DataBase.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

public static class ProductManager
{
    public static async Task<List<Product>> GetFullSellerProductsAsync(int sellerId)
    {
        await using var dbContext = new DataBaseContext();

        return dbContext.Products.Include(product => product.ProductCategory).Include(product => product.Seller).Where(product => product.Seller.Id == sellerId).ToList();
    }

    public static async Task AddNewSellerProductAsync(int sellerId)
    {
        await using var dbContext = new DataBaseContext();

        var productCategory = dbContext.ProductCategories.First();
        var seller = dbContext.Sellers.Include(c => c.Products).First(c => c.Id == sellerId);

        var newProduct = new Product
                         {
                         Count = 0,
                         Description = "0",
                         Name = "",
                         Price = 0,
                         Seller = seller,
                         ProductCategory = productCategory
                         };

        seller.Products.Add(newProduct);
        await dbContext.Products.AddAsync(newProduct);

        await dbContext.SaveChangesAsync();
    }

    public static async Task DeleteProductAsync(int id)
    {
        await using var dbContext = new DataBaseContext();

        var product = await ProductManager.GetProductAsync(id);

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
    }

    public static async Task<Product?> GetProductAsync(int id)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
    }
}
