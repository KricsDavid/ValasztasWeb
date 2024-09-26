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
            List<Part > partok = new List<Part>();
            while (!sr.EndOfStream)
            {


                var part = sr.ReadLine().Split()[4];
                if (!_context.Partok.Select(x => x.rovidnev).Contains(part))
                {
                    _context.Partok.Add(new Part { rovidnev = part });

                }
               

            }
            sr.Close();
            foreach (var p in partok)
            {
                _context.Partok.Add(p);
            }

            sr = new StreamReader(UploadFilePath);
            while (!sr.EndOfStream)
            {
                var sor = sr.ReadLine();
                var elemek = sor.Split();
                Jelolt ujJelolt = new Jelolt();
                ujJelolt.Kerulet = int.Parse(elemek[0]);
                ujJelolt.szavazatszam = int.Parse(elemek[1]);
                ujJelolt.Nev = elemek[2]+ " " + elemek[3];
                ujJelolt.PartRovidNev = elemek[4];

                _context.Jeloltek.Add(ujJelolt);
            }


            _context.SaveChanges();


            return Page();

            }





        
}
                
        }

       
    

