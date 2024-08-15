using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMovieApp.Data;
using RazorMovieApp.Models;

namespace RazorMovieApp.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovieDbContext _context;

        // dependancy injected by .net in constructor
        public IndexModel(RazorMovieDbContext context)
        {
            _context = context;
        }

        // === Model Propertues ===
        public IList<Movie> Movies { get; set;} = default!;
        public int Operations {get; set;}

        [BindProperty(SupportsGet = true)]
        public string ? SearchString {get; set;}

        public SelectList ? Genres {get;set;}

        [BindProperty(SupportsGet = true)]
        public string ? GenreSearchString {get; set;}

        // === Get Request Handler ===
        public async Task OnGetAsync()
        {
            // grab data from db
            // var dbMovies = await _context.Movie.ToListAsync();

            var movies = 
                from movie in _context.Movie
                select movie;

            var genreQuery =
                from movie in _context.Movie
                orderby movie.Genre
                select movie.Genre;

            // if search string has value perform filter
            if(!string.IsNullOrEmpty(SearchString)) 
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }  
            
            
            // if genre search string has value perform filter by genre
            if(!string.IsNullOrEmpty(GenreSearchString)) 
            {
                movies = movies.Where(m => m.Genre == GenreSearchString);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()); // async task returns all genres by running genreQuery against db
            Movies = await movies.ToListAsync(); // Async task to run movie query or assing prop value from genre or search filter
            
        }
    }
}
