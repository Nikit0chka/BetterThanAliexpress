namespace DataBase.DataBaseManagers;

using Microsoft.EntityFrameworkCore;

public static class AdminManager
{
    public static async Task RegistrationAdminAsync(string login, string password)
    {
        var newAdmin = new Admin { Login = login, Password = password };

        await using var dbContext = new DataBaseContext();
        await dbContext.Admins.AddAsync(newAdmin);
        await dbContext.SaveChangesAsync();
    }

    public static async Task<bool> IsAdminPasswordCorrectAsync(string login, string password)
    {
        await using var dbContext = new DataBaseContext();
        var admin = await dbContext.Admins.FirstOrDefaultAsync(admin => admin.Login == login);

        return admin != null && admin.Password == password;
    }
}
