using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string BuildSynopsis { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<PricingTier> PricingTiers { get; set; }
    }
}