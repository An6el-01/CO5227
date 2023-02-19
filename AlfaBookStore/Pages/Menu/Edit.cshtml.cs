using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlfaBookStore.Data;
using AlfaBookStore.model;
using static System.Reflection.Metadata.BlobBuilder;

namespace AlfaBookStore.Pages.Menu
{
    public class EditModel : PageModel
    {
        private readonly AlfaBookStore.Data.AlfaBookStoreContext _context;

        public EditModel(AlfaBookStore.Data.AlfaBookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books =  await _context.Books.FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }
            Book = books;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            // handle uploaded file
            if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        Book.Image = memoryStream.ToArray();
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Menu/IndexMenu");
        }


        private bool BooksExists(int id)
        {
          return _context.Books.Any(e => e.ID == id);
        }
    }
}
