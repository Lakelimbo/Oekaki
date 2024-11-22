using System.ComponentModel.DataAnnotations;

namespace Oekaki.Data.Models;

/**
    This is just a test table
**/

public sealed class Test
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
}
