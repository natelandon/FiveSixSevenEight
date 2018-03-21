using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FiveSixSevenEight.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }
        [Display(Name = "Event Type")]
        public string DanceEventType { get; set; }

        [Display(Name = "Event Category")]
        public ICollection<DanceEventCategory> DanceEventCategories { get; set; }
    }
}
