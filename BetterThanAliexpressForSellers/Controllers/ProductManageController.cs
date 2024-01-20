namespace BetterThanAliexpressForSellers.Controllers;

using DataBase.DataBaseManagers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public sealed class ProductManageController : Controller
{
    [Authorize] public async Task<IActionResult> ManageProduct(int productId)
    {
        var product = await ProductManager.GetProductAsync(productId);

        if (product is null)
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");

        return View(product);
    }
}
