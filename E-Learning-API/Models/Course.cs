using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_API.Models.Enum;

namespace E_Learning_API.Models;

public record Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string? Title { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? LastUpdate { get; set; } = null;

    public string? Content { get; set; }

    public Published Published { get; set; }

    public LevelCourse Level { get; set; }

    public ICollection<Tag>? Tags { get; set; }

    public Assignement? Assignement { get; set; }

}
