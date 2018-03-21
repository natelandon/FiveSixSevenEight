using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveSixSevenEight.Models.DanceViewModels
{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }
        public string DanceEventType { get; set; }
        public bool Assigned { get; set; }
    }
}
