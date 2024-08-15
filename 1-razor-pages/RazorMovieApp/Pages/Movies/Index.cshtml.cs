using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        // public SelectList Genres {get;set;}

        [BindProperty(SupportsGet = true)]
        public string ? MovieGenre {get; set;}

        // === Get Request Handler ===
        public async Task OnGetAsync()
        {
            // grab data from db
            var dbMovies = await _context.Movie.ToListAsync();

            // if search string has value perform filter
            if(!string.IsNullOrEmpty(SearchString)) 
            {
                var filteredMovies = dbMovies.ToList().Where(m => m.Title.Contains(SearchString));
                Movies = filteredMovies.ToList();
            } else 
            {
                // else save all db movies into Movies prop
                Movies = dbMovies;
            }            
        }
    }
}
