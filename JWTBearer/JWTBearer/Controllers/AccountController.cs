using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTBearer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    [HttpGet("profile")]
    [Authorize]
    public string Profile()
    {
        return "Profile";
    }

    [HttpGet]
    public string GetToken()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "fuga02@gmail.com")
            };
            var signInKey = System.Text.Encoding.UTF32.GetBytes("qwertyuiopasdfghjkl12345609890823");
            var security = new JwtSecurityToken(
                issuer: "Identity.Api",
                audience:"Products",
                claims: claims,
                expires:DateTime.Now.AddSeconds(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signInKey),SecurityAlgorithms.HmacSha256)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(security);
            return token;
    }
}