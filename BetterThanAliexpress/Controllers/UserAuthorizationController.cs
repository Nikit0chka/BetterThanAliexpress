namespace BetterThanAliexpress.Controllers;

using EntityFramework;

using Microsoft.AspNetCore.Mvc;

using Models;

public sealed class UserAuthorizationController : Controller
{
    public IActionResult UserAuthorization() => View();

    [HttpPost] public IActionResult UserAuthorization(UserAuthorizationModel userAuthorizationModel)
    {
        using var dbContext = new DataBaseContext();
        var userWithLogin = dbContext.Buyers.FirstOrDefault(buyer => buyer.Login == userAuthorizationModel.Login || buyer.PhoneNumber == userAuthorizationModel.Login || buyer.Email == userAuthorizationModel.Login);

        if (!ModelState.IsValid)
            return View();

        if (userWithLogin is null)
        {
            ModelState.AddModelError(key: "Login", errorMessage: "There are no user with this login");

            return View();
        }

        if (userWithLogin.Password == userAuthorizationModel.Password)
            return RedirectToAction(actionName: "UserMainPage", controllerName: "UserMainPage");

        ModelState.AddModelError(key: "Password", errorMessage: "Password is not correct");

        return View();
    }
}
