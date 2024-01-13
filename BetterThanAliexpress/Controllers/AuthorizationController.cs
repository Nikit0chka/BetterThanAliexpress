namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

using Models;

public sealed class AuthorizationController : Controller
{
    public IActionResult Authorization() => View();

    [HttpPost] public async Task<IActionResult> Authorization(AuthorizationModel authorizationModel)
    {
        if (await AdminManager.IsAdminInDataBaseAsync(login: authorizationModel.Login, password: authorizationModel.Password))
            return RedirectToAction(actionName: "AdminMainPage", controllerName: "AdminMainPage", routeValues: new { login = authorizationModel.Login, password = authorizationModel.Password });

        if (!ModelState.IsValid)
            return View();

        if (!await BuyerManager.IsBuyerInDataBaseAsync(authorizationModel.Login))
        {
            ModelState.AddModelError(key: "Login", errorMessage: "User with this login not registered");

            return View();
        }

        if (await BuyerManager.IsBuyerPasswordCorrectAsync(login: authorizationModel.Login, password: authorizationModel.Password))
            return RedirectToAction(actionName: "UserMainPage", controllerName: "UserMainPage", routeValues: new { userLogin = authorizationModel.Login, userPassword = authorizationModel.Password });

        ModelState.AddModelError(key: "Password", errorMessage: "Password is not correct");

        return View();
    }
}
