namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPostActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPostActivities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        JobPostingId = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false),
                        JobApplicationStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApplicationStatus", t => t.JobApplicationStatusId, cascadeDelete: true)
                .ForeignKey("dbo.JobPostings", t => t.JobPostingId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.JobPostingId)
                .Index(t => t.JobApplicationStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostActivities", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.JobPostActivities", "JobPostingId", "dbo.JobPostings");
            DropForeignKey("dbo.JobPostActivities", "JobApplicationStatusId", "dbo.JobApplicationStatus");
            DropIndex("dbo.JobPostActivities", new[] { "JobApplicationStatusId" });
            DropIndex("dbo.JobPostActivities", new[] { "JobPostingId" });
            DropIndex("dbo.JobPostActivities", new[] { "Id" });
            DropTable("dbo.JobPostActivities");
        }
    }
}
