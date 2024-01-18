namespace BetterThanAliexpress.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public sealed class CartController : Controller
{
    [Authorize] public IActionResult Cart() => View();
}
