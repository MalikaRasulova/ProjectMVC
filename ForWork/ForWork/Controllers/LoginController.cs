using ForWork.Dtos;
using ForWork.IICUTechservice;
using ForWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForWork.Controllers;

public class LoginController : Controller
{
    private readonly ICUTechClient _client;

    public LoginController(ICUTechClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        return View(new LoginViewModel()
        {
            IsSuccess = true
        });
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromForm] LoginDto loginDto)
    {
        try
        {
            LoginResponse? response =
                await _client.LoginAsync(loginDto.username, loginDto.password, base.Request.Host.Host);
            ArgumentNullException.ThrowIfNull(response);
            return View("Index", new LoginViewModel()
            {
                Response = response.@return,
                IsSuccess = true
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return View("Index", new LoginViewModel()
            {
                Response = null,
                IsSuccess = false,
                Error = e
            });
        }
    }
}