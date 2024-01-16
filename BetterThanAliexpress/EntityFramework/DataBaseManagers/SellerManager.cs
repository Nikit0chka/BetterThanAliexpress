namespace BetterThanAliexpress.EntityFramework.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

using Models;

internal static class SellerManager
{
    internal static async Task RegistrationSellerAsync(SellerRegistrationModel sellerRegistrationModel)
    {
        var newSeller = new Seller
                        {
                        Login = sellerRegistrationModel.Login,
                        Password = sellerRegistrationModel.Password,
                        PhoneNumber = sellerRegistrationModel.PhoneNumber,
                        CompanyAddress = sellerRegistrationModel.CompanyAddress,
                        Email = sellerRegistrationModel.Email,
                        Inn = sellerRegistrationModel.Inn,
                        Name = sellerRegistrationModel.Name,
                        IsAdminConfirmed = false
                        };

        await using var dbContext = new DataBaseContext();
        await dbContext.Sellers.AddAsync(newSeller);
        await dbContext.SaveChangesAsync();
    }

    internal static async Task<bool> IsSellerInDataBaseAsync(string login)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Sellers.AnyAsync(seller => seller.Login == login || seller.PhoneNumber == login || seller.Email == login || seller.Inn == login);
    }

    internal static async Task<bool> IsSellerPasswordCorrectAsync(int id, string password)
    {
        await using var dbContext = new DataBaseContext();
        var seller = await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);

        return seller is not null && seller.Password == password;
    }

    internal static async Task<bool> IsSellerPasswordCorrectAsync(string login, string password)
    {
        await using var dbContext = new DataBaseContext();
        var seller = await dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Login == login);

        return seller is not null && seller.Password == password;
    }
}
