using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Data.Models;

namespace MoviesApp.Pages
{
    public class MoviesModel : PageModel
    {

        public  List<Movie> Movies { get; set; }

        private ApplicationDbContext _content;

        public MoviesModel(ApplicationDbContext context)
        {
            _content = context;
        }

        public void OnGet()
        {
            Movies = _content.Movies.ToList();

        }
    }
}
