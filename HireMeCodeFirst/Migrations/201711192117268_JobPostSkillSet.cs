namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPostSkillSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPostSkillSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobPostingId = c.Int(nullable: false),
                        SkillLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPostings", t => t.JobPostingId, cascadeDelete: true)
                .Index(t => t.JobPostingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPostSkillSets", "JobPostingId", "dbo.JobPostings");
            DropIndex("dbo.JobPostSkillSets", new[] { "JobPostingId" });
            DropTable("dbo.JobPostSkillSets");
        }
    }
}
