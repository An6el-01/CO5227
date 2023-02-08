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
    public class IndexModel : PageModel
    {
        private readonly AlfaBookStore.Data.AlfaBookStoreContext _context;

        public IndexModel(AlfaBookStore.Data.AlfaBookStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }
    }
}
