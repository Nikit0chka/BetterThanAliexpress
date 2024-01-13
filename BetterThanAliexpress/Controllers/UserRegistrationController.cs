namespace BetterThanAliexpress.Controllers;

using EntityFramework;
using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

using Models;

using System.Diagnostics;

public sealed class UserRegistrationController : Controller
{
    public IActionResult UserRegistration() => View();


    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    [HttpPost] public async Task<IActionResult> UserRegistration(UserRegistrationModel userRegistrationModel)
    {
        var buyers = new DataBaseContext().Buyers.ToList();

        if (!ModelState.IsValid)
            return View();

        if (buyers.Any(buyer => buyer.Login == userRegistrationModel.Login))
        {
            ModelState.AddModelError(key: "Login", errorMessage: "User with this login is already registered");

            return View();
        }

        if (buyers.Any(buyer => buyer.PhoneNumber == userRegistrationModel.PhoneNumber))
        {
            ModelState.AddModelError(key: "PhoneNumber", errorMessage: "User with this phone number is already registered");

            return View();
        }

        if (buyers.Any(buyer => buyer.Email == userRegistrationModel.Email))
        {
            ModelState.AddModelError(key: "Email", errorMessage: "User with this email is already registered");

            return View();
        }

        await BuyerManager.RegistrationBuyerAsync(name: userRegistrationModel.Name, surname: userRegistrationModel.Surname, login: userRegistrationModel.Login, password: userRegistrationModel.Password, dateOfBirthday: userRegistrationModel.DateOfBirthday, email: userRegistrationModel.Email, phoneNumber: userRegistrationModel.PhoneNumber);

        return RedirectToAction(actionName: "Authorization", controllerName: "Authorization");
    }
}
