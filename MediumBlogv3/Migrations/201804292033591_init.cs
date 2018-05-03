namespace MediumBlogv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "CompanyName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Authors", "CompanyZip", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "CompanyCity", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "CompanyCity");
            DropColumn("dbo.Authors", "CompanyZip");
            DropColumn("dbo.Authors", "CompanyName");
        }
    }
}
