using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int StarRating { get; set; }
        public string ImageURL { get; set; }
        public string Text { get; set; }

    }
}