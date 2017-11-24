namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPostActivityLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPostActivityLogs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        JobPostActivityId = c.Int(nullable: false),
                        JobPostActionId = c.Int(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPostActions", t => t.JobPostActionId, cascadeDelete: true)
                .ForeignKey("dbo.JobPostActivities", t => t.JobPostActivityId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.JobPostActivityId)
                .Index(t => t.JobPostActionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostActivityLogs", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.JobPostActivityLogs", "JobPostActivityId", "dbo.JobPostActivities");
            DropForeignKey("dbo.JobPostActivityLogs", "JobPostActionId", "dbo.JobPostActions");
            DropIndex("dbo.JobPostActivityLogs", new[] { "JobPostActionId" });
            DropIndex("dbo.JobPostActivityLogs", new[] { "JobPostActivityId" });
            DropIndex("dbo.JobPostActivityLogs", new[] { "Id" });
            DropTable("dbo.JobPostActivityLogs");
        }
    }
}
