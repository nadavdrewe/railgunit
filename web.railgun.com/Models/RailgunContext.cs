using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using web.railgun.com.Models.Mapping;
using web.railgun.com.Models.Configuration;

namespace web.railgun.com.Models
{
    public partial class railgunContext : DbContext
    {
        static railgunContext()
        {
            Database.SetInitializer<railgunContext>(null);
        }

        public railgunContext()
            : base("Name=railgunContext")
        {
        }
          public DbSet<AspNetRole> AspNetRoles { get; set; }
          public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
          public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
          public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PricingTier> PricingTiers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new ProjectConfiguration());

            modelBuilder.Entity<Feature>()
    .HasOptional(x => x.Category)
    .WithMany()
    .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<PricingTier>()
    .HasOptional(x => x.Category)
    .WithMany()
    .HasForeignKey(x => x.CategoryId);

        }



    }
}
