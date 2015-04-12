namespace web.railgun.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Categories = c.String(),
                        TeamLead = c.String(),
                        TechnologiesUsed = c.String(),
                        DateInitiated = c.String(),
                        Clients = c.String(),
                        Description = c.String(),
                        Summary = c.String(),
                        ProjectURL = c.String(),
                        Graphic1 = c.String(),
                        Graphic2 = c.String(),
                        Graphic3 = c.String(),
                        Graphic4 = c.String(),
                        GraphicTiny = c.String(),
                        Logo = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "CategoryId", "dbo.Categories");        
            DropTable("dbo.Project");
            DropTable("dbo.Categories");          
        }
    }
}
