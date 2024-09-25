using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
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


        public async Task<IActionResult> OnPostAsync() {
           
            return Page();

            }



        var UploadFilePath = Path.Combine(_env.ContentRootPath, "uploads", UploadFile.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                return Page();
    await UploadFile.CopyToAsync(stream);
}
                
        }

       
    }

