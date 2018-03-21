using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveSixSevenEight.Models
{
    public class DanceEventCategory
    {
        public int DanceEventCategoryID { get; set; }

        public int DanceEventID { get; set; }
        public int CategoryID { get; set; }

        public DanceEvent DanceEvent { get; set; }
        public Category Category { get; set; }
    }
}
