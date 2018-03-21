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
    public class IndexModel : PageModel
    {
        private readonly FiveSixSevenEight.Data.DanceContext _context;

        public IndexModel(FiveSixSevenEight.Data.DanceContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
