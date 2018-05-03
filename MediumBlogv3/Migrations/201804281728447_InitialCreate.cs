namespace MediumBlogv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 40),
                        AuthorName = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Tag = c.Int(nullable: false),
                        FeaturedImageURL = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 60),
                        AuthorID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.BlogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Posts", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "BlogID" });
            DropIndex("dbo.Posts", new[] { "AuthorID" });
            DropTable("dbo.Blogs");
            DropTable("dbo.Posts");
            DropTable("dbo.Authors");
        }
    }
}
