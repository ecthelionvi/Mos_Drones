using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly UserRepository _userRepository;

    public AuthController(IConfiguration config)
    {
        _config = config;
        _userRepository = new UserRepository();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Authenticate the user
        var user = _userRepository.GetUserByEmail(model.Email);

        if (user != null && model.Password == "password")
        {
            // Generate JWT token with role
            var token = GenerateJwtToken(model.Email, user.Role);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(string email, string role)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role),
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Set token expiration time
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class ProtectedController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        // Get the authenticated user's email from the claims
        var email = User.FindFirst(ClaimTypes.Email)?.Value;

        // Return a response with the authenticated user's email
        return Ok(new { Message = $"Hello, {email}! This is a protected endpoint." });
    }
}
