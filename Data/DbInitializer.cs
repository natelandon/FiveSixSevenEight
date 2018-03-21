using System;
using System.Linq;
using FiveSixSevenEight.Models;
using Microsoft.AspNetCore;


namespace FiveSixSevenEight.Data
{
    public class DbInitializer
    {
        public static void Initialize(DanceContext context)
        {
            context.Database.EnsureCreated();

            if (context.DanceEvents.Any())
            {
                return;
            }

            var danceevents = new DanceEvent[]
            {
                new DanceEvent{DanceEventName="Lindy Focus", EventDate=DateTime.Parse("12-26-2018"), City="Ashville", State="North Carolina", Website="http://www.LindyFocus.com"},
                new DanceEvent{DanceEventName="Lindy on the Rocks", EventDate=DateTime.Parse("9-14-2018"), City="Denver", State="Colorado", Website="http://www.lindyontherocks.com/"},
                new DanceEvent{DanceEventName="DCLX", EventDate=DateTime.Parse("04-20-2017"), City="Washington", State="D.C.", Website="https://dclx.org/"},
                new DanceEvent{DanceEventName="International Lindy Hop Championships", EventDate=DateTime.Parse("08-23-2017"), City="Alexandria", State="Virginia", Website="http://www.ilhc.com/"}
            };
            foreach (DanceEvent e in danceevents)
            {
                context.DanceEvents.Add(e);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{CategoryID=1, DanceEventType="Workshop"},
                new Category{CategoryID=2, DanceEventType="Exchange"},
                new Category{CategoryID=3, DanceEventType="Competition"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var danceeventcategories = new DanceEventCategory[]
            {
                new DanceEventCategory{DanceEventID=1, CategoryID=1},
                new DanceEventCategory{DanceEventID=1, CategoryID=3},
                new DanceEventCategory{DanceEventID=2, CategoryID=1},
                new DanceEventCategory{DanceEventID=3, CategoryID=2},
                new DanceEventCategory{DanceEventID=4, CategoryID=3},
            };
            foreach (DanceEventCategory d in danceeventcategories)
            {
                context.DanceEventCategories.Add(d);
            }
            context.SaveChanges();
        }
    }
}