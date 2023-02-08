using System;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Books { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Books);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
