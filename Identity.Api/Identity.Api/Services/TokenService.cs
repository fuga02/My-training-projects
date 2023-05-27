using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Api.Entities;
using Identity.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Services;

public class TokenService
{
    private readonly JwtOption _jwtOption;

    public TokenService(IOptions<JwtOption> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }


    public string GenerateToken(User user)
    {

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username!)
        };
        var signInKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SignInKey);
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddSeconds(_jwtOption.ExpiresInSecunds),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signInKey), SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(security);
        return token;
    }
}