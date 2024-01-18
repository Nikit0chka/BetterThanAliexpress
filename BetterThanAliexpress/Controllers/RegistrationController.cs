namespace BetterThanAliexpress.Controllers;

using DataBase;
using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using Models;

using System.Globalization;
using System.Security.Claims;

public sealed class RegistrationController : Controller
{
    public IActionResult Registration() => View();

    [HttpPost] public async Task<IActionResult> Registration(RegistrationModel registrationModel)
    {
        if (await BuyerManager.IsBuyerInDataBaseAsync(registrationModel.Login))
            ModelState.AddModelError(key: nameof(registrationModel.Login), errorMessage: "User with this login is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(registrationModel.PhoneNumber))
            ModelState.AddModelError(key: nameof(registrationModel.PhoneNumber), errorMessage: "User with this phone number is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(registrationModel.Email))
            ModelState.AddModelError(key: nameof(registrationModel.Email), errorMessage: "User with this email is already registered");

        if (!ModelState.IsValid)
            return View();

        await BuyerManager.RegistrationBuyerAsync(name: registrationModel.Name, surname: registrationModel.Surname, login: registrationModel.Login, password: registrationModel.Password, dateOfBirthday: registrationModel.DateOfBirthday, email: registrationModel.Email, phoneNumber: registrationModel.PhoneNumber);

        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new Claim(type: nameof(Buyer.Login), value: registrationModel.Login));

        await HttpContext.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: new ClaimsPrincipal(identity));

        return RedirectToAction(actionName: nameof(AuthorizationController.Authorization), controllerName: "Authorization");
    }
}
