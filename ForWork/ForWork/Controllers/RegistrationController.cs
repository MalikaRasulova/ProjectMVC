using ForWork.Dtos;
using ForWork.IICUTechservice;
using ForWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForWork.Controllers;

public class RegistrationController:Controller
{
    private readonly ICUTechClient _client;

    public RegistrationController(ICUTechClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
  
        return View("Register",new RegistrationViewModel()
        {
            IsSuccess = true
        });
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromForm] RegistrationDto Dto)
    {
        try
        {
            RegisterNewCustomerResponse response =
                await _client.RegisterNewCustomerAsync(Dto.Email, Dto.Password,
                    Dto.FirstName,Dto.LastName,
                    Dto.Mobil,Dto.CountryId
                    ,Dto.AId,base.Request.Host.Host);
            ArgumentNullException.ThrowIfNull(response);
            return View("Register", new RegistrationViewModel()
            {
                Response = response.@return,
                IsSuccess = false,
            } );
        }
        catch (Exception e)
        {
            return View("Register", new RegistrationViewModel()
            {
                Response = null,
                IsSuccess = false,
                Error = e
            });
        }
    }
}