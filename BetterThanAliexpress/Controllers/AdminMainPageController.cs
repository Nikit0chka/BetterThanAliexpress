namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

public sealed class AdminMainPageController : Controller
{
    public async Task<IActionResult> AdminMainPage(string login, string password)
    {
        if (!await AdminManager.IsAdminInDataBaseAsync(login: login, password: password))
            return RedirectToAction(actionName: "UserMainPage", controllerName: "UserMainPage");

        return View();
    }
}
