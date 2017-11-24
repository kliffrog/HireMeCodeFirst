namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        CellPhone = c.String(),
                        CellProvider = c.String(),
                        Website = c.String(),
                        EmployerViewing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentProfiles", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.StudentProfiles", new[] { "UserAccountId" });
            DropTable("dbo.StudentProfiles");
        }
    }
}
