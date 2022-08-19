using System;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models;

public class Courses
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

}

