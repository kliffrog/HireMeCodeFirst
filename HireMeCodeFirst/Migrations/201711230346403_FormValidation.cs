namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobPostings", "JobTitle", c => c.String(nullable: false));
            AlterColumn("dbo.JobPostings", "JobDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobPostings", "JobDescription", c => c.String());
            AlterColumn("dbo.JobPostings", "JobTitle", c => c.String());
        }
    }
}
