using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace web.railgun.com.Models
{
    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
        public string BusinessName { get; set; }
        public string CompanyContact { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTel { get; set; }
        public string Notes { get; set; }

    }
}