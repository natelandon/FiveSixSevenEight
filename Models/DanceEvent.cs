using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveSixSevenEight.Models
{
    public class DanceEvent
    {

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Event Name")]
        public string DanceEventName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Website { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Event Category")]
        public ICollection<DanceEventCategory> DanceEventCategories { get; set; }
    }
}
