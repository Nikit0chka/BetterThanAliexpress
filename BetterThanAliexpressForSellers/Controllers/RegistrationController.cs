namespace BetterThanAliexpressForSellers.Controllers;

using DataBase;
using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using Models;

using System.Security.Claims;

public sealed class RegistrationController : Controller
{
    public IActionResult Registration() => View();

    [HttpPost] public async Task<IActionResult> Registration(RegistrationModel registrationModel)
    {
        if (await SellerManager.IsSellerInDataBaseAsync(registrationModel.Login))
            ModelState.AddModelError(key: nameof(registrationModel.Login), errorMessage: "User with this login is already registered");

        if (await SellerManager.IsSellerInDataBaseAsync(registrationModel.PhoneNumber))
            ModelState.AddModelError(key: nameof(registrationModel.PhoneNumber), errorMessage: "User with this phone number is already registered");

        if (await SellerManager.IsSellerInDataBaseAsync(registrationModel.Email))
            ModelState.AddModelError(key: nameof(registrationModel.Email), errorMessage: "User with this email is already registered");

        if (!ModelState.IsValid)
            return View();


        await SellerManager.RegistrationSellerAsync(login: registrationModel.Login, password: registrationModel.Password, phoneNumber: registrationModel.PhoneNumber, companyAddress: registrationModel.CompanyAddress, email: registrationModel.Email, inn: registrationModel.Inn, name: registrationModel.Name);

        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new Claim(type: nameof(Seller.Login), value: registrationModel.Login));

        await HttpContext.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: new ClaimsPrincipal(identity));

        return RedirectToAction(actionName: nameof(MainPageController.MainPage), controllerName: "MainPage");
    }
}
