namespace BetterThanAliexpress.EntityFramework.DataBaseManagers;

internal static class BuyerManager
{
    internal static async Task RegistrationBuyer(string name, string surname, string login, string password, DateTime dateOfBirthday, string email, string phoneNumber)
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
}
