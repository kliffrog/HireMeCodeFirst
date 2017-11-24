namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobApplicationStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplicationStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobApplicationStatus");
        }
    }
}
