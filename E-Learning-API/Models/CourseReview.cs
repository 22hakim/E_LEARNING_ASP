namespace E_Learning_API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_API.Models.Enum;

public record CourseReview
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public RateCourse Rate { get; set; }

    [Required]
    [StringLength(maximumLength: 500, MinimumLength = 3,ErrorMessage = "should be between 3 and 500 characters.")]
    public string Comment { get;  set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}

