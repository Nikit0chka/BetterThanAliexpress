namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

public sealed class SellerMainPageController : Controller
{
    private string? _sellerLogin;
    private string? _sellerPassword;

    public async Task<IActionResult> SellerMainPage(string login, string password)
    {
        _sellerLogin = login;
        _sellerPassword = password;

        if (!await SellerManager.IsSellerPasswordCorrectAsync(login: login, password: password))
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        return View();
    }
}
