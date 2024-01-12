using Microsoft.AspNetCore.Mvc;

namespace BetterThanAliexpress.Controllers; 

public sealed class UserMainPageController : Controller {
    public IActionResult UserMainPage() => View();
}
