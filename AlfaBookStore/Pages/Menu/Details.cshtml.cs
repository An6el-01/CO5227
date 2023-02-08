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
    public class DetailsModel : PageModel
    {
        private readonly AlfaBookStore.Data.AlfaBookStoreContext _context;

        public DetailsModel(AlfaBookStore.Data.AlfaBookStoreContext context)
        {
            _context = context;
        }

      public Book Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FirstOrDefaultAsync(m => m.id == id);
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
    }
}
