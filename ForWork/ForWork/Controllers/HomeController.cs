using System.Diagnostics;
using ForWork.IICUTechservice;
using Microsoft.AspNetCore.Mvc;
using ForWork.Models;

namespace ForWork.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICUTechClient _techClient;

    public HomeController(ILogger<HomeController> logger, ICUTechClient techClient)
    {
        _logger = logger;
        _techClient = techClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}