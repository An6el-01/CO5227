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

          //Trying to figure out why when I edit the money on the creat and edit page it takes it in as a decimal and tries to convert it to string instead of money???
            //decimal decimalValue = (decimal)Books.Price;
            //System.Data.SqlTypes.SqlMoney moneyValue = (System.Data.SqlTypes.SqlMoney)decimalValue;


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

            return RedirectToPage("./Index");
        }
    }
}
