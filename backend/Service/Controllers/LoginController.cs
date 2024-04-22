using Managers;
using Microsoft.AspNetCore.Mvc;
using Managers.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller {
    
    [HttpPost]
    public void SaveUser(string firstName, string lastName, string email, string password, string city, string state, string zipCode, string addressLine)
    {
        AccountManager.AddAccount(firstName, lastName, email, password, city, state, zipCode, addressLine);
    }

    [HttpPost]
    public JsonResult ValidateLogin(String username, String password)
    {
        Account? account = AccountManager.ValidateLogin(username, password);
        return new JsonResult(account);
    }
}