using CSharpMySite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpMySite.Pages
{
    public class MoviesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public class MovieViewModel
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public string GenreName { get; set; }
        }

        public List<MovieViewModel> Items { get; set; }

        public MoviesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Items = _context.Movies.Select(m => new MovieViewModel
            {
                Director = m.Director,
                GenreName = m.Genre.Name,
                Title = m.Title,
            }).ToList();
        }
    }
}
