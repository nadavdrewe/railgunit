using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.railgun.com.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Request { get; set; }
        public string Phone { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
