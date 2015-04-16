using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models
{
    public partial class Project
    {
        public Project()
        {

            //init default
            if (this.InProgress == null)
            {
                this.InProgress = false;
            }

        }

        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Categories { get; set; }
        public string TeamLead { get; set; }
        public string TechnologiesUsed { get; set; }
        public Nullable<DateTime> DateInitiated { get; set; }
        public string Clients { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ProjectURL { get; set; }
        public string Graphic1 { get; set; }
        public string Graphic2 { get; set; }
        public string Graphic3 { get; set; }
        public string Graphic4 { get; set; }
        public string GraphicTiny { get; set; }
        public string Logo { get; set; }
        public string GitRepo { get; set; }
        public string CompanyURL { get; set; }
        public string CompanyDescription { get; set; }

        public Nullable<bool> InProgress { get; set; }

        //foriegn keys
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}