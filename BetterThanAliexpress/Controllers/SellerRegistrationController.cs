namespace BetterThanAliexpress.Controllers;

using EntityFramework.DataBaseManagers;

using Microsoft.AspNetCore.Mvc;

using Models;

public sealed class SellerRegistrationController : Controller
{
    // GET
    public IActionResult SellerRegistration() => View();

    [HttpPost] public async Task<IActionResult> SellerRegistration(SellerRegistrationModel sellerRegistrationModel)
    {
        if (await BuyerManager.IsBuyerInDataBaseAsync(sellerRegistrationModel.Login) || await SellerManager.IsSellerInDataBaseAsync(sellerRegistrationModel.Login))
            ModelState.AddModelError(key: nameof(sellerRegistrationModel.Login), errorMessage: "User with this login is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(sellerRegistrationModel.PhoneNumber) || await SellerManager.IsSellerInDataBaseAsync(sellerRegistrationModel.PhoneNumber))
            ModelState.AddModelError(key: nameof(sellerRegistrationModel.PhoneNumber), errorMessage: "User with this phone number is already registered");

        if (await BuyerManager.IsBuyerInDataBaseAsync(sellerRegistrationModel.Email) || await SellerManager.IsSellerInDataBaseAsync(sellerRegistrationModel.Email))
            ModelState.AddModelError(key: nameof(sellerRegistrationModel.Email), errorMessage: "User with this email is already registered");


        if (await SellerManager.IsSellerInDataBaseAsync(sellerRegistrationModel.Inn))
            ModelState.AddModelError(key: nameof(sellerRegistrationModel.Inn), errorMessage: "Seller with this inn is already registered");

        if (!ModelState.IsValid)
            return View();

        await SellerManager.RegistrationSellerAsync(sellerRegistrationModel);

        return RedirectToAction(actionName: nameof(SellerMainPageController.SellerMainPage), controllerName: "SellerMainPage", routeValues: new { login = sellerRegistrationModel.Login, password = sellerRegistrationModel.Password });
    }
}
