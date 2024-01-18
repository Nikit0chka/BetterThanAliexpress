namespace BetterThanAliexpress.Controllers;

using Microsoft.AspNetCore.Mvc;

public sealed class MainPageController : Controller
{
    public IActionResult MainPage() => View();

    public IActionResult OpenUserCart() => RedirectToAction(actionName: "Cart", controllerName: "Cart");
}
