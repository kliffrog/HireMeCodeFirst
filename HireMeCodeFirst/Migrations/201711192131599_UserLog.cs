namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.Int(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        LastApplyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogs", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.UserLogs", new[] { "UserAccountId" });
            DropTable("dbo.UserLogs");
        }
    }
}
