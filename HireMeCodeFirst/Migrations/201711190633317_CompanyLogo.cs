namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyLogo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyLogos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyLogos", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompanyLogos", new[] { "CompanyId" });
            DropTable("dbo.CompanyLogos");
        }
    }
}
