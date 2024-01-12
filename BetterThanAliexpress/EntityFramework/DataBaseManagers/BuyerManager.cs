namespace BetterThanAliexpress.EntityFramework.DataBaseManagers;

internal static class BuyerManager
{
    internal static void RegistrationBuyer(string name, string surname, string login, string password, DateTime dateOfBirthday, string email, string phoneNumber)
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

        var dbContext = new DataBaseContext();
        dbContext.Buyers.Add(newBuyer);
        dbContext.SaveChanges();
        var asdf = dbContext.Buyers.ToList();
        var alo = 1;
        var alo1 = asdf.Count;
        alo1 += 1;
    }
}
