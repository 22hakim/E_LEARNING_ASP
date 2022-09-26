using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace E_Learning_API.Models.Dtos;

public class UserLoginRequestDto
{

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}

