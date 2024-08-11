using System;
using System.ComponentModel.DataAnnotations;

namespace RazorMovieApp.Models;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = null!;
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    public string Genre { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }
}
