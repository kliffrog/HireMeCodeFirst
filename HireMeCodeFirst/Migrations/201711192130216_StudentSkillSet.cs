namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentSkillSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSkillSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.Int(nullable: false),
                        SkillSetId = c.Int(nullable: false),
                        SkillLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillSets", t => t.SkillSetId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId)
                .Index(t => t.SkillSetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSkillSets", "UserAccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.StudentSkillSets", "SkillSetId", "dbo.SkillSets");
            DropIndex("dbo.StudentSkillSets", new[] { "SkillSetId" });
            DropIndex("dbo.StudentSkillSets", new[] { "UserAccountId" });
            DropTable("dbo.StudentSkillSets");
        }
    }
}
