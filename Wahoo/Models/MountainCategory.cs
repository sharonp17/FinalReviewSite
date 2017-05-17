using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Wahoo.Models
{
    public class MountainCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [DisplayName("Trail Name")]
        public string TrailName { get; set; }
        [DisplayName("Trail Location")]
        public string TrailLocation { get; set; }
        public string Elevation { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

    }
}