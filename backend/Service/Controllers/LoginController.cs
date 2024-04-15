using Microsoft.AspNetCore.Mvc;
using Managers.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller {
    
    [HttpPost]
    public JsonResult SaveUser(User user)
    {
        //used for adding a new account
        return new JsonResult();
    }

    [HttpPost]
    public JsonResult ValidateLogin(String username, String password)
    {
        //should hit db to get account by email
        //should hit engine to validate password
        //returns user object
    }
}