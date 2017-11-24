namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VerifyPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "VerifyPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "VerifyPassword");
        }
    }
}
