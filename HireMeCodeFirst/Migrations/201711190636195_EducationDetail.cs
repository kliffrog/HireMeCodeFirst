namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EducationDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountID = c.Int(nullable: false),
                        CertificateDegree = c.String(),
                        Major = c.String(),
                        InstitutionName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                        Percentage = c.Int(nullable: false),
                        GPA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationDetails", "UserAccountID", "dbo.UserAccounts");
            DropIndex("dbo.EducationDetails", new[] { "UserAccountID" });
            DropTable("dbo.EducationDetails");
        }
    }
}
