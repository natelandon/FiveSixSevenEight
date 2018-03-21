using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FiveSixSevenEight.Data;
using FiveSixSevenEight.Models;

namespace FiveSixSevenEight.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly FiveSixSevenEight.Data.DanceContext _context;

        public CreateModel(FiveSixSevenEight.Data.DanceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}