using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_API.Models;

public record CourseUpdate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Course Course { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime UpdatedAt { get; set; }
}

