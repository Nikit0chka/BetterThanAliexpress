namespace BetterThanAliexpress.Controllers;

using Microsoft.AspNetCore.Mvc;

public class UserCartController : Controller
{
    public IActionResult UserCart(string userLogin, string userPassword) => View();
}
