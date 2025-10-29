using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stanciu_Oana_Lab2.Data;
using Stanciu_Oana_Lab2.Models;

namespace Stanciu_Oana_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Stanciu_Oana_Lab2.Data.Stanciu_Oana_Lab2Context _context;

        public DetailsModel(Stanciu_Oana_Lab2.Data.Stanciu_Oana_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
        .Include(b => b.Publisher)
        .Include(b => b.BookCategories)
        .ThenInclude(bc => bc.Category)
        .FirstOrDefaultAsync(b => b.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
