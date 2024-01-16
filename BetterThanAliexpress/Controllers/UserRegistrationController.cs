namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

using Models;

public sealed class UserRegistrationController : Controller
{
    public IActionResult UserRegistration() => View();

    [HttpPost] public async Task<IActionResult> UserRegistration(UserRegistrationModel userRegistrationModel)
    {
        if (await BuyerManager.IsBuyerInDataBaseAsync(userRegistrationModel.Login) || await SellerManager.IsSellerInDataBaseAsync(userRegistrationModel.Login))
            ModelState.AddModelError(key: nameof(userRegistrationModel.Login), errorMessage: "User with this login is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(userRegistrationModel.PhoneNumber) || await SellerManager.IsSellerInDataBaseAsync(userRegistrationModel.PhoneNumber))
            ModelState.AddModelError(key: nameof(userRegistrationModel.PhoneNumber), errorMessage: "User with this phone number is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(userRegistrationModel.Email) || await SellerManager.IsSellerInDataBaseAsync(userRegistrationModel.Email))
            ModelState.AddModelError(key: nameof(userRegistrationModel.Email), errorMessage: "User with this email is already registered");

        if (!ModelState.IsValid)
            return View();

        await BuyerManager.RegistrationBuyerAsync(name: userRegistrationModel.Name, surname: userRegistrationModel.Surname, login: userRegistrationModel.Login, password: userRegistrationModel.Password, dateOfBirthday: userRegistrationModel.DateOfBirthday, email: userRegistrationModel.Email, phoneNumber: userRegistrationModel.PhoneNumber);

        return RedirectToAction(actionName: "Authorization", controllerName: "Authorization");
    }
}
