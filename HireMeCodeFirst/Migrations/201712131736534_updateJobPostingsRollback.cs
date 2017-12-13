namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJobPostingsRollback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPostActivities", "JobPostingId", "dbo.JobPostings");
            DropForeignKey("dbo.JobPostSkillSets", "JobPostingId", "dbo.JobPostings");
            DropIndex("dbo.JobPostings", new[] { "Id" });
            DropPrimaryKey("dbo.JobPostings");
            AlterColumn("dbo.JobPostings", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.JobPostings", "Id");
            CreateIndex("dbo.JobPostings", "Id");
            AddForeignKey("dbo.JobPostActivities", "JobPostingId", "dbo.JobPostings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobPostSkillSets", "JobPostingId", "dbo.JobPostings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostSkillSets", "JobPostingId", "dbo.JobPostings");
            DropForeignKey("dbo.JobPostActivities", "JobPostingId", "dbo.JobPostings");
            DropIndex("dbo.JobPostings", new[] { "Id" });
            DropPrimaryKey("dbo.JobPostings");
            AlterColumn("dbo.JobPostings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.JobPostings", "Id");
            CreateIndex("dbo.JobPostings", "Id");
            AddForeignKey("dbo.JobPostSkillSets", "JobPostingId", "dbo.JobPostings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobPostActivities", "JobPostingId", "dbo.JobPostings", "Id", cascadeDelete: true);
        }
    }
}
