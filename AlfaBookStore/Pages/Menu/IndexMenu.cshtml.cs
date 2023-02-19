using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlfaBookStore.Data;
using AlfaBookStore.model;
using Microsoft.Extensions.Logging;

namespace AlfaBookStore.Pages.Menu
{
    public class IndexModel : PageModel
    {
        private readonly AlfaBookStoreContext _context;
        public IList<Books> Book { get; set; } = default!;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(AlfaBookStore.Data.AlfaBookStoreContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }

    }
}
