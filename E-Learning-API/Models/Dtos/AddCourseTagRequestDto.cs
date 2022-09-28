using System;
using E_Learning_API.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models.Dtos;

public class AddCourseTagRequestDto
{
    [Required]
    public int TagId { get; set; }

    [Required]
    public int CourseID { get; set; }
    
}

