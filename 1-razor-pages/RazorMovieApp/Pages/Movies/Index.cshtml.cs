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
        private readonly RazorMovieApp.Data.RazorMovieDbContext _context;

        public IndexModel(RazorMovieApp.Data.RazorMovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
