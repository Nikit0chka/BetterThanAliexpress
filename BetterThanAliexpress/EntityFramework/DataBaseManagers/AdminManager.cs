namespace BetterThanAliexpress.EntityFramework.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

internal static class AdminManager
{
    internal static async Task RegistrationAdminAsync(string login, string password)
    {
        var newAdmin = new Admin { Login = login, Password = password };

        await using var dbContext = new DataBaseContext();
        await dbContext.Admins.AddAsync(newAdmin);
        await dbContext.SaveChangesAsync();
    }

    internal static async Task<bool> IsAdminInDataBaseAsync(string login, string password)
    {
        await using var dbContext = new DataBaseContext();

        return await dbContext.Admins.AnyAsync(admin => admin.Login == login && admin.Password == password);
    }
}
