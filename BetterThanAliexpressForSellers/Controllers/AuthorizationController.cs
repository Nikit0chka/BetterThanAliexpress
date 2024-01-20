namespace BetterThanAliexpressForSellers.Controllers;

using DataBase;
using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using Models;

using System.Security.Claims;

public sealed class AuthorizationController : Controller
{
    public IActionResult Authorization() => View();

    [HttpPost] public async Task<IActionResult> Authorization(AuthorizationModel authorizationModel)
    {
        if (!await SellerManager.IsSellerInDataBaseAsync(authorizationModel.Login))
            ModelState.AddModelError(key: "Login", errorMessage: "Seller with this login not registered");

        if (!await SellerManager.IsSellerPasswordCorrectAsync(login: authorizationModel.Login, password: authorizationModel.Password))
            ModelState.AddModelError(key: "Password", errorMessage: "Password is not correct");

        if (!ModelState.IsValid)
            return View();

        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new Claim(type: nameof(Seller.Login), value: authorizationModel.Login));

        await HttpContext.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: new ClaimsPrincipal(identity));

        return RedirectToAction(actionName: nameof(MainPageController.MainPage), controllerName: "MainPage");
    }
}
