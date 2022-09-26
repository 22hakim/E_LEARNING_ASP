using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Learning_API.Authentication;

public class JWTAuthentication
{
    public string Secret { get; set; }

    public string GenerateToken(IdentityUser identityUser,IConfiguration configuration)
    {
        JwtSecurityTokenHandler jwtHandler = new();


        var key = Encoding.UTF8.GetBytes(configuration.GetSection("JWTAuthentication:Secret").Value);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            // -> payload data 
            Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                new Claim("Id", identityUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
            }),
            // durée de vie du token 
            Expires = DateTime.Now.AddHours(1),
            // ici on intégre notre clé créée -> verify signature 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        // crée le token 
        var token = jwtHandler.CreateToken(tokenDescriptor);
        // converti le token en string et le renvoi 
        return jwtHandler.WriteToken(token);
    }
}

