using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class PricingTier
    {

        [Key]
        public int PricingTierId { get; set; }
        public string TierName { get; set; }
        public string FromPrice { get; set; }

        public Nullable<int> CategoryId { get;set;}

        public virtual Category Category { get; set; }

        

    }
}