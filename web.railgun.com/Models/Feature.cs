using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        
        public string Description {get;set;}
        public string ShortDescription { get; set; }
        public string SubDescription { get; set; }

        public Nullable<decimal> FeatureSoloPrice { get;set;}


        public Nullable<int> CategoryId { get; set; }
        public virtual Category Category { get; set; }
        

        public Nullable<int> PricingTierId { get; set; }
        public virtual PricingTier PricingTier { get; set; }


    }


}