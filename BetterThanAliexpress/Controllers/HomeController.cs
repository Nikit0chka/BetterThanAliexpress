namespace BetterThanAliexpress.Controllers;

using Microsoft.AspNetCore.Mvc;

using Models;

using System.Diagnostics;

public sealed class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    public IActionResult NavigateToUserRegistration() => RedirectToAction(actionName: "UserRegistration", controllerName: "UserRegistration");

    public IActionResult NavigateToUserAuthorization() => RedirectToAction(actionName: "UserAuthorization", controllerName: "UserAuthorization");

    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
