using Managers;
using Microsoft.AspNetCore.Mvc;
using Managers.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private static int? _AccountId = 3;
    
    public static int? AccountId
    {
        get { return _AccountId; }
    }

    [HttpPost("auth")]
    public JsonResult ValidateLogin([FromBody]LoginRequest loginRequest)
    {
        Account? account = AccountManager.ValidateLogin(loginRequest.Email, loginRequest.Password);
        _AccountId = account?.AccountId;
        return AccountId is null ? Json("Incorrect Email and Password") : Json(account);
    }
    
    [HttpPost("Logout")]
    public void Logout()
    {
        _AccountId = null;
    }
    
    [HttpPost("CreateAccount")]
    public void CreateAccount([FromBody] Account account)
    {
        AccountManager.AddAccount(account);
    }
}
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}