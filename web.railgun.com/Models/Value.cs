using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class Value
    {
        [Key]
        public int ValueId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ValueDescription { get; set; }
        public string IconClass { get; set; }
    }
}