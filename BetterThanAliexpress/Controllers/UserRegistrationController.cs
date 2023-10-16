using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BetterThanAliexpress.Models;

namespace BetterThanAliexpress.Controllers;

public class UserRegistrationController : Controller
{
    private readonly ILogger<UserRegistrationController> _logger;

    public UserRegistrationController(ILogger<UserRegistrationController> logger)
    {
        _logger = logger;
    }

    public IActionResult SDf()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}