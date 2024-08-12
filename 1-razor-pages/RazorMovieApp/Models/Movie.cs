using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorMovieApp.Models;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = null!;
    
    [DataType(DataType.Date)] [Display (Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    public string Genre { get; set; } = null!;
    
    [Required] [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
