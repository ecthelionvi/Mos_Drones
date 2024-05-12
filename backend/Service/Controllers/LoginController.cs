using Managers;
using Managers.Account;
using Managers.Account.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    public static int? AccountId = null;
    private readonly IAccountManager _accountManager;

    public LoginController(IAccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    [HttpPost("auth")]
    public JsonResult ValidateLogin([FromBody]LoginRequest loginRequest)
    {
        Account? account = _accountManager.ValidateLogin(loginRequest.Email, loginRequest.Password);
        AccountId = account?.AccountId;
        return AccountId is null ? Json("Incorrect Email and Password") : Json(account);
    }
    
    [HttpPost("Logout")]
    public void Logout()
    {
        AccountId = null;
    }
    
    [HttpPost("CreateAccount")]
    public void CreateAccount([FromBody] Account account)
    {
        _accountManager.AddAccount(account);
    }
}
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}