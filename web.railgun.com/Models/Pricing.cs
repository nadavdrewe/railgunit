using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class Pricing
    {

        [Key]
        public int PricingID { get; set; }
        public string PricingName { get; set; }

       
        //foriegn keys
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PricingTierId { get;set; }
        public virtual Pricing Pricing { get; set; }



    }
}