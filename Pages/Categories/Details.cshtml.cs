using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FiveSixSevenEight.Data;
using FiveSixSevenEight.Models;

namespace FiveSixSevenEight.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly FiveSixSevenEight.Data.DanceContext _context;

        public DetailsModel(FiveSixSevenEight.Data.DanceContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoryID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
