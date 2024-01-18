namespace BetterThanAliexpressForSellers.Controllers;

using DataBase;
using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public sealed class MainPageController : Controller
{
    [Authorize] public async Task<IActionResult> MainPage()
    {
        var sellerLogin = HttpContext.Request.Cookies[nameof(Seller.Login)];

        if (sellerLogin == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        var seller = await SellerManager.GetSellerAsync(sellerLogin);

        if (seller == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        return View(seller.Products.ToList());
    }

    [HttpPost] [Authorize] public async Task<IActionResult> AddProduct()
    {
        var sellerLogin = HttpContext.Request.Cookies[nameof(Seller.Login)];

        if (sellerLogin == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        var seller = await SellerManager.GetSellerAsync(sellerLogin);

        if (seller == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        await SellerManager.AddNewProductAsync(seller.Id);

        return RedirectToAction(actionName: nameof(MainPageController.MainPage), controllerName: "MainPage");
    }
}
