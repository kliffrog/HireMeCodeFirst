namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentExperience : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.Int(nullable: false),
                        CurrentJob = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        JobTitle = c.String(),
                        CompanyName = c.String(),
                        JobCity = c.String(),
                        JobState = c.String(),
                        JobCountry = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentExperiences", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.StudentExperiences", new[] { "UserAccountId" });
            DropTable("dbo.StudentExperiences");
        }
    }
}
