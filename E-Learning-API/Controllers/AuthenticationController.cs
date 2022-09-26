using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_Learning_API.Authentication;
using E_Learning_API.Models;
using E_Learning_API.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_Learning_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController(UserManager<IdentityUser> userManager,
    IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            var emailExist = await _userManager.FindByEmailAsync(requestDto.Email);
            if (emailExist is not null)
                return BadRequest(AuthenticationMessage.MailAlreadyExists());

            var newUser = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Name
            };

            var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);
            if (isCreated.Succeeded)
            {
                var jwtAuth = new JWTAuthentication();
                var token = jwtAuth.GenerateToken(newUser, _configuration);
                return Ok(AuthenticationMessage.TokenCreated(token));
            }
            return BadRequest(AuthenticationMessage.CreationFailed());
        }
        return BadRequest();
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);
            if (existingUser is not null)
            {
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, requestDto.Password);
                if(isCorrect is false)
                {
                    return BadRequest(AuthenticationMessage.WrongPassword());
                }

                var jwtAuth = new JWTAuthentication();
                var token = jwtAuth.GenerateToken(existingUser, _configuration);
                return Ok(AuthenticationMessage.TokenCreated(token));
            }
            return BadRequest(AuthenticationMessage.NoUserExisting());
        }
        return BadRequest(AuthenticationMessage.WrongField());
    }
}

