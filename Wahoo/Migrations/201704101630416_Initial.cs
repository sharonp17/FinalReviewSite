namespace Wahoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MountainCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        TrailName = c.String(),
                        TrailLocation = c.String(),
                        Elevation = c.String(),
                        ReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewerName = c.String(),
                        ReviewDate = c.String(),
                        Comments = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MountainCategories", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.MountainCategories", new[] { "ReviewId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.MountainCategories");
        }
    }
}
