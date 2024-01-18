namespace DataBase.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

public static class SellerManager
{
    public static async Task RegistrationSellerAsync(string login, string password, string phoneNumber, string companyAddress, string email, string inn, string name)
    {
        var newSeller = new Seller
                        {
                        Login = login,
                        Password = password,
                        PhoneNumber = phoneNumber,
                        CompanyAddress = companyAddress,
                        Email = email,
                        Inn = inn,
                        Name = name,
                        IsAdminConfirmed = false,
                        Products = new List<Product>()
                        };

        await using var dbContext = new DataBaseContext();
        await dbContext.Sellers.AddAsync(newSeller);
        await dbContext.SaveChangesAsync();
    }

    public static async Task<bool> IsSellerInDataBaseAsync(string login)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Sellers.AnyAsync(seller => seller.Login == login || seller.PhoneNumber == login || seller.Email == login || seller.Inn == login);
    }

    public static async Task<bool> IsSellerPasswordCorrectAsync(int id, string password)
    {
        await using var dbContext = new DataBaseContext();
        var seller = await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);

        return seller is not null && seller.Password == password;
    }

    public static async Task<bool> IsSellerPasswordCorrectAsync(string login, string password)
    {
        await using var dbContext = new DataBaseContext();
        var seller = await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Login == login || seller.PhoneNumber == login || seller.Email == login || seller.Inn == login);

        return seller is not null && seller.Password == password;
    }

    public static async Task<Seller?> GetSellerAsync(string login)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Login == login || seller.PhoneNumber == login || seller.Email == login || seller.Inn == login);
    }

    public static async Task<Seller?> GetSellerAsync(int id)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);
    }

    public static async Task AddNewProductAsync(int id)
    {
        await using var dbContext = new DataBaseContext();

        var seller = await SellerManager.GetSellerAsync(id);

        if (seller is null)
            throw new Exception("there are no seller with this id");

        var newProduct = new Product
                         {
                         Count = 0,
                         Description = "0",
                         Name = "",
                         Price = 0,
                         Seller = seller,
                         ProductCategory = dbContext.ProductCategories.ToList()[0]
                         };

        seller.Products.Add(newProduct);
        await dbContext.Products.AddAsync(newProduct);
        
        await dbContext.SaveChangesAsync();
    }
}
