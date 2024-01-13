namespace BetterThanAliexpress.Controllers;

using Microsoft.AspNetCore.Mvc;

public sealed class UserMainPageController : Controller
{
    private string _userLogin = null!;
    private string _userPassword = null!;

    public IActionResult UserMainPage(string userPassword, string userLogin)
    {
        _userPassword = userPassword;
        _userLogin = userLogin;

        return View();
    }

    public IActionResult OpenUserCart() => RedirectToAction(actionName: "UserCart", controllerName: "UserCart", routeValues: new { userLogin = _userLogin, userPassword = _userPassword });
}
