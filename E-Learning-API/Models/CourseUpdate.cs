using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_API.Models;

public class CourseUpdate
{
    public int Id { get; set; }

    public Course Course { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime UpdatedAt { get; set; }
}

