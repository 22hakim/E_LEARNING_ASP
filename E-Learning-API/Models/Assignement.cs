using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_API.Models;

public class Assignement
{
    public int Id { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public string[]? ListVideosUrl { get; set; }

    public string[]? ListText { get; set; }
}


