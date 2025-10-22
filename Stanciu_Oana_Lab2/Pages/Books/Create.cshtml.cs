using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stanciu_Oana_Lab2.Data;
using Stanciu_Oana_Lab2.Models;

namespace Stanciu_Oana_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Stanciu_Oana_Lab2.Data.Stanciu_Oana_Lab2Context _context;

        public CreateModel(Stanciu_Oana_Lab2.Data.Stanciu_Oana_Lab2Context context)
        {
            _context = context;

        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        public SelectList AuthorsSL { get; set; } = default!;
        public SelectList PublishersSL { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AuthorsSL = new SelectList(_context.Author, "ID", "FullName", Book.AuthorID);
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName", Book.PublisherID);
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
