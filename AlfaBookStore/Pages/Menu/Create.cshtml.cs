using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlfaBookStore.Data;
using AlfaBookStore.model;

namespace AlfaBookStore.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly AlfaBookStore.Data.AlfaBookStoreContext _context;

        public CreateModel(AlfaBookStore.Data.AlfaBookStoreContext context)
        {
            _context = context;
        }
        public bool IsImageValid(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return false;
            }

            try
            {
                using (var ms = new MemoryStream(imageData))
                {
                    var image = System.Drawing.Image.FromStream(ms);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Books Books { get; set; } = new Books();


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public IActionResult GetBookImage(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null || book.Image == null)
            {
                return NotFound();
            }
            return File(book.Image, "image/jpg");
        }


        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

         
            foreach (var file in Request.Form.Files) 
            { 
                MemoryStream ms= new MemoryStream();
                file.CopyTo(ms);
                Books.Image = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            _context.Books.Add(Books);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Menu/IndexMenu");
        }
    }
}
