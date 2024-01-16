namespace BetterThanAliexpress.Controllers;

using EntityFramework;
using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public sealed class AdminMainPageController : Controller
{
    public async Task<IActionResult> AdminMainPage(string login, string password)
    {
        if (!await AdminManager.IsAdminPasswordCorrectAsync(login: login, password: password))
            return RedirectToAction(actionName: "UserMainPage", controllerName: "UserMainPage");

        return View();
    }

    public IActionResult AdminBuyersManagement()
    {
        var dbContext = new DataBaseContext();

        return View(dbContext.Buyers.ToList());
    }

    public async Task<IActionResult> DeleteBuyer(int id)
    {
        await using var dbContext = new DataBaseContext();
        var buyer = dbContext.Buyers.FirstAsync(buyer => buyer.Id == id);

        dbContext.Remove(buyer);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(AdminMainPageController.AdminBuyersManagement));
    }
}
