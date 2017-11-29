namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAccountIdCompanyTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "UserAccountId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "UserAccountId", c => c.Int(nullable: false));
        }
    }
}
