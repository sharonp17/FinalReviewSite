using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Wahoo.Models
{
    public class Review
    {
        [DisplayName("Review")]
        public int ReviewId { get; set; }
        [DisplayName("Reviewer Name")]
        public string ReviewerName { get; set; }
        [DisplayName("Review Date")]
        public string ReviewDate { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public string Mountain { get; set; }
        public virtual ICollection<MountainCategory> MountainCategory { get; set; }
    }
}