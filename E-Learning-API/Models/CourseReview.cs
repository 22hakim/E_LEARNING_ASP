namespace E_Learning_API.Models;

using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_API.Models.Enum;

public class CourseReview
{
    public int Id { get; set; }

    public RateCourse Rate { get; set; }

    public string Comment { get;  set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}

