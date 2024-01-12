using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using BetterThanAliexpress.Models;

namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

public sealed class UserRegistrationController : Controller
{
    public IActionResult UserRegistration() => View();


    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    [HttpPost] public async Task<IActionResult> UserRegistration(UserRegistrationModel userRegistrationModel)
    {
        //var buyers = new DataBaseContext().Buyers.ToList();

        if (!ModelState.IsValid)
            return View();

        // if (buyers.Any(buyer => buyer.Login == userRegistrationModel.Login)){
        //     ModelState.AddModelError("Login", "User with this login is already registered");
        //     return View();
        // }
        //
        // if (buyers.Any(buyer => buyer.PhoneNumber == userRegistrationModel.PhoneNumber)){
        //     ModelState.AddModelError("PhoneNumber", "User with this phone number is already registered");
        //     return View();
        // }
        //
        // if (buyers.Any(buyer => buyer.Email == userRegistrationModel.Email)){
        //     ModelState.AddModelError("Email", "User with this email is already registered");
        //     return View();
        // }

        BuyerManager.RegistrationBuyer(name: userRegistrationModel.Name, surname: userRegistrationModel.Surname, login: userRegistrationModel.Login, password: userRegistrationModel.Password, dateOfBirthday: userRegistrationModel.DateOfBirthday, email: userRegistrationModel.Email, phoneNumber: userRegistrationModel.PhoneNumber);

        return RedirectToAction(actionName: "UserMainPage", controllerName: "UserMainPage");
    }
}
