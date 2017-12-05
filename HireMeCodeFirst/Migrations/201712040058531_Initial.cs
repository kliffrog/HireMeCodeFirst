namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPostings", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.JobPostings", new[] { "UserAccountId" });
            AddColumn("dbo.UserAccounts", "VerifyPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "UserAccountId", c => c.String());
            AlterColumn("dbo.JobPostings", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "StartDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "EndDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "PostingDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "ExpirationDate", c => c.DateTime());
            CreateIndex("dbo.AspNetUsers", "UserTypeId");
            AddForeignKey("dbo.AspNetUsers", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.JobPostings", "UserAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPostings", "UserAccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.AspNetUsers", new[] { "UserTypeId" });
            AlterColumn("dbo.JobPostings", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "PostingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "UserAccountId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserTypeId");
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "Enabled");
            DropColumn("dbo.UserAccounts", "VerifyPassword");
            CreateIndex("dbo.JobPostings", "UserAccountId");
            AddForeignKey("dbo.JobPostings", "UserAccountId", "dbo.UserAccounts", "Id", cascadeDelete: true);
        }
    }
}
