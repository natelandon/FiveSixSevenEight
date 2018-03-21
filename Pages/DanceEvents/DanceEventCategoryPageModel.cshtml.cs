using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiveSixSevenEight.Data;
using FiveSixSevenEight.Models;
using FiveSixSevenEight.Models.DanceViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiveSixSevenEight.Pages.DanceEvents
{
    public class DanceEventCategoryPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(DanceContext context, DanceEvent danceevent)
        {
            var allCategories = context.Categories;
            var danceeventCategories = new HashSet<int>(
                danceevent.DanceEventCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var category in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                    {
                    CategoryID = category.CategoryID,
                    DanceEventType = category.DanceEventType,
                    Assigned = danceeventCategories.Contains(category.CategoryID)
                });
            }
        }

        public void UpdateDanceEventCategories (DanceContext context,
            string[] selectedCategories, DanceEvent danceeventToUpdate)
        {
            if (selectedCategories == null)
            {
                danceeventToUpdate.DanceEventCategories = new List<DanceEventCategory>();
                return;
            }

            var selectedCategoryHS = new HashSet<string>(selectedCategories);
            var danceeventCategory = new HashSet<int>
                (danceeventToUpdate.DanceEventCategories.Select(c => c.Category.CategoryID));
            foreach (var category in context.Categories)
            {
                if (selectedCategoryHS.Contains(category.CategoryID.ToString()))
                    {
                    if (!danceeventCategory.Contains(category.CategoryID))
                    {
                        danceeventToUpdate.DanceEventCategories.Add(
                            new DanceEventCategory
                            {
                            DanceEventID = danceeventToUpdate.ID,
                            CategoryID = category.CategoryID
                        });
                    }
                }
                else
                {
                    if (danceeventCategory.Contains(category.CategoryID))
                    {
                        DanceEventCategory categoryToRemove
                            = danceeventToUpdate
                            .DanceEventCategories
                            .SingleOrDefault(i => i.CategoryID == category.CategoryID);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}
