namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJobPostingDatesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobPostings", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "StartDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "EndDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "PostingDate", c => c.DateTime());
            AlterColumn("dbo.JobPostings", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobPostings", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "PostingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobPostings", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
