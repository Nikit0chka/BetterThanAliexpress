namespace BetterThanAliexpressForSellers.Controllers;

using DataBase;
using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public sealed class MainPageController : Controller
{
    [Authorize] public async Task<IActionResult> MainPage()
    {
        var sellerLogin = HttpContext.User.FindFirst(nameof(Seller.Login));

        if (sellerLogin == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        var seller = await SellerManager.GetSellerAsync(sellerLogin.Value);

        if (seller == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        return View(await ProductManager.GetFullSellerProductsAsync(seller.Id));
    }

    [Authorize] public async Task<IActionResult> AddProductAsync()
    {
        var sellerLogin = HttpContext.User.FindFirst(nameof(Seller.Login));

        if (sellerLogin == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        var seller = await SellerManager.GetSellerAsync(sellerLogin.Value);

        if (seller == null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        await ProductManager.AddNewSellerProductAsync(seller.Id);

        return RedirectToAction(actionName: nameof(MainPageController.MainPage), controllerName: "MainPage");
    }

    [Authorize] public async Task<IActionResult> DeleteProductAsync(int productId)
    {
        await ProductManager.DeleteProductAsync(productId);

        return RedirectToAction(actionName: nameof(MainPageController.MainPage), controllerName: "MainPage");
    }
}
