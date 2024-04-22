using Managers;
using Microsoft.AspNetCore.Mvc;
using Managers.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller {
    
    [HttpPost]
    public JsonResult SaveUser(Account userAccount)
    {
        //used for adding a new account
        return new JsonResult();
    }

    [HttpPost]
    public JsonResult ValidateLogin(String username, String password)
    {
        Account? account = AccountManager.ValidateLogin(username, password);
    }
}