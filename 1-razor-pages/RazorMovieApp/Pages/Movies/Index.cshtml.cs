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

        public IList<Movie> Movies { get;set; } = default!;
        public int Operations {get; set;}

        public async Task OnGetAsync()
        {
            Movies = await _context.Movie.ToListAsync();
        }
    }
}
