using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoviesApp.Pages
{
    public class AddMovieModel : PageModel
    {
        public string Title { get; set; }
        public int Rate {  get; set; }
        
        public string Description { get; set; }

        public void OnGet()
        {
        }
    }
}
