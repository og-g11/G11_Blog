namespace Blog.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Content_ID = c.Int(),
                        Creator_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contents", t => t.Content_ID)
                .ForeignKey("dbo.Users", t => t.Creator_ID)
                .Index(t => t.Content_ID)
                .Index(t => t.Creator_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Live_Title = c.String(nullable: false, maxLength: 100),
                        Live_Summary = c.String(maxLength: 250),
                        Live_Text = c.String(nullable: false),
                        Draft_Title = c.String(nullable: false, maxLength: 100),
                        Draft_Summary = c.String(maxLength: 250),
                        Draft_Text = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_ID = c.Int(nullable: false),
                        Creator_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Users", t => t.Creator_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Creator_ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OriginalFileName = c.String(nullable: false, maxLength: 50),
                        Type = c.Byte(nullable: false),
                        Content_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contents", t => t.Content_ID)
                .Index(t => t.Content_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Creator_ID", "dbo.Users");
            DropForeignKey("dbo.Photos", "Content_ID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Creator_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Content_ID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Photos", new[] { "Content_ID" });
            DropIndex("dbo.Contents", new[] { "Creator_ID" });
            DropIndex("dbo.Contents", new[] { "Category_ID" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Comments", new[] { "Creator_ID" });
            DropIndex("dbo.Comments", new[] { "Content_ID" });
            DropTable("dbo.Photos");
            DropTable("dbo.Contents");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
