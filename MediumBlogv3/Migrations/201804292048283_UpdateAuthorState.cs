namespace MediumBlogv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "CompanyState", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "CompanyState");
        }
    }
}
