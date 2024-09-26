using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Valasztas.Models;
using Microsoft.EntityFrameworkCore;

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
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync() {

            var UploadFilePath = Path.Combine(_env.ContentRootPath, "uploads", UploadFile.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await UploadFile.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);

            while (!sr.EndOfStream)
            {


                var part = sr.ReadLine().Split()[4];
                if (!_context.Partok.Select(x => x.rovidnev).Contains(part))
                {
                    _context.Partok.Add(new Part { rovidnev = part });

                }
               

            }
            sr.Close();

            _context.SaveChanges();


            return Page();

            }





        
}
                
        }

       
    

