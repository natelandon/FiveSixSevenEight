using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FiveSixSevenEight.Data;
using FiveSixSevenEight.Models;
using Microsoft.AspNetCore.Authorization;

namespace FiveSixSevenEight.Pages.DanceEvents
{
    [Authorize]
    public class CreateModel : DanceEventCategoryPageModel
    {
        private readonly FiveSixSevenEight.Data.DanceContext _context;

        public CreateModel(FiveSixSevenEight.Data.DanceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var danceevent = new DanceEvent();
            danceevent.DanceEventCategories = new List<DanceEventCategory>();
            PopulateAssignedCategoryData(_context, danceevent);
            return Page();
        }



        [BindProperty]
        public DanceEvent DanceEvent { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newDanceEvent = new DanceEvent();
            if (selectedCategories != null)
            {
                newDanceEvent.DanceEventCategories = new List<DanceEventCategory>();
                foreach (var category in selectedCategories)
                {
                    var categoryToAdd = new DanceEventCategory
                    {
                        CategoryID = int.Parse(category)
                    };
                    newDanceEvent.DanceEventCategories.Add(categoryToAdd);
                };
            }

            if (await TryUpdateModelAsync<DanceEvent>(
                newDanceEvent,
                "danceevent",
                e => e.DanceEventName, e => e.EventDate, e => e.City, e => e.State, e => e.Website))
            {
                _context.DanceEvents.Add(newDanceEvent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDanceEvent);
            return Page();
        }
    }
}