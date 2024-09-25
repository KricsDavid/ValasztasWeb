using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Valasztas.Models;

namespace Valasztas.Pages
{
    public class AdatfelvModel : PageModel
    {

        [BindProperty]

        public IFormFile UploadFile {  get; set; }

        private readonly IWebHostEnvironment _env;
        private readonly ValasztasDbContext _context;

        public AdatfelvModel(IWebHostEnvironment env, ValasztasDbContext context)
        {
            _context = context;
            _env = env;
        }

        public void OnGet()
        {
        }





    }
}
