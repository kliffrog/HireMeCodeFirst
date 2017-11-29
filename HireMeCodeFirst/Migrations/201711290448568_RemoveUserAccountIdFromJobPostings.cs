namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserAccountIdFromJobPostings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPostings", "UserAccount_Id", "dbo.UserAccounts");
            DropIndex("dbo.JobPostings", new[] { "UserAccount_Id" });
            DropColumn("dbo.JobPostings", "UserAccountId");
            DropColumn("dbo.JobPostings", "UserAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPostings", "UserAccount_Id", c => c.Int());
            AddColumn("dbo.JobPostings", "UserAccountId", c => c.String());
            CreateIndex("dbo.JobPostings", "UserAccount_Id");
            AddForeignKey("dbo.JobPostings", "UserAccount_Id", "dbo.UserAccounts", "Id");
        }
    }
}
