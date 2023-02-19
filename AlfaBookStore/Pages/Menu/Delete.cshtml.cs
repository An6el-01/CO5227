using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlfaBookStore.Data;
using AlfaBookStore.model;

namespace AlfaBookStore.Pages.Menu
{
    public class DeleteModel : PageModel
    {
        private readonly AlfaBookStore.Data.AlfaBookStoreContext _context;

        public DeleteModel(AlfaBookStore.Data.AlfaBookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FirstOrDefaultAsync(m => m.ID == id);

            if (books == null)
            {
                return NotFound();
            }
            else 
            {
                Books = books;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var books = await _context.Books.FindAsync(id);

            if (books != null)
            {
                Books = books;
                _context.Books.Remove(Books);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Menu/IndexMenu");
        }
    }
}
