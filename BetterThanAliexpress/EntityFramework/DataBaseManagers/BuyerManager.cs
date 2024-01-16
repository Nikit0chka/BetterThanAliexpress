namespace BetterThanAliexpress.EntityFramework.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

internal static class BuyerManager
{
    internal static async Task RegistrationBuyerAsync(string name, string surname, string login, string password, DateTime dateOfBirthday, string email, string phoneNumber)
    {
        var newBuyer = new Buyer
                       {
                       Name = name,
                       Surname = surname,
                       Login = login,
                       Password = password,
                       DateOfBirthday = dateOfBirthday,
                       Email = email,
                       PhoneNumber = phoneNumber
                       };

        await using var dbContext = new DataBaseContext();
        await dbContext.Buyers.AddAsync(newBuyer);
        await dbContext.SaveChangesAsync();
    }

    internal static async Task<bool> IsBuyerInDataBaseAsync(string login)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Buyers.AnyAsync(buyer => buyer.Login == login || buyer.PhoneNumber == login || buyer.Email == login);
    }

    internal static async Task<bool> IsBuyerPasswordCorrectAsync(string login, string password)
    {
        await using var dbContext = new DataBaseContext();

        var buyerWithLogin = await dbContext.Buyers.FirstOrDefaultAsync(buyer => buyer.Login == login || buyer.PhoneNumber == login || buyer.Email == login);

        return buyerWithLogin != null && buyerWithLogin.Password == password;
    }
}
