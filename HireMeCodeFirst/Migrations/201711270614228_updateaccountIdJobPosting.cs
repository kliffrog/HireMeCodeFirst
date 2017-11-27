namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaccountIdJobPosting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPostings", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.JobPostings", new[] { "UserAccountId" });
            AddColumn("dbo.JobPostings", "UserAccount_Id", c => c.Int());
            AlterColumn("dbo.JobPostings", "UserAccountId", c => c.String());
            CreateIndex("dbo.JobPostings", "UserAccount_Id");
            AddForeignKey("dbo.JobPostings", "UserAccount_Id", "dbo.UserAccounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostings", "UserAccount_Id", "dbo.UserAccounts");
            DropIndex("dbo.JobPostings", new[] { "UserAccount_Id" });
            AlterColumn("dbo.JobPostings", "UserAccountId", c => c.Int(nullable: false));
            DropColumn("dbo.JobPostings", "UserAccount_Id");
            CreateIndex("dbo.JobPostings", "UserAccountId");
            AddForeignKey("dbo.JobPostings", "UserAccountId", "dbo.UserAccounts", "Id", cascadeDelete: true);
        }
    }
}
