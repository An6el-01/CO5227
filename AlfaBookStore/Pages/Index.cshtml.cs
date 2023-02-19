using AlfaBookStore.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlfaBookStore.Data;

namespace AlfaBookStore.Pages;

    public class IndexModel : PageModel { 
    

        private readonly AlfaBookStoreContext _context;

        public IndexModel(AlfaBookStoreContext context)
        {
            _context = context;
        }

        public IList<Books> Books { get; set; }

        // Add this property to your class
        public IList<Books> BooksOfTheWeek
        {
            get
            {
                // Get the two books you want to display as "Books of the Week"
                return _context.Books.Take(2).ToList();
            }
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }

    }
