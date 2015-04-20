using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberId { get; set; }
        public string Name { get; set; }
        public string JobRole { get; set; }
        public string PictureURL { get; set; }
        public string Summary { get; set; }
        public string EmailAddress { get; set; }

        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }

    }
}