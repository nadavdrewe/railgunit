using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace web.railgun.com.Models.Configuration
{
    
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
            : base()
        {
            HasKey(p => p.ProjectId);
            ToTable("Project");

            HasRequired(t => t.Category);
                
        }
    }

}