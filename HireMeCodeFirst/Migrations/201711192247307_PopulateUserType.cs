namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserTypes (Name) VALUES ('Admin')");
            Sql("INSERT INTO UserTypes (Name) VALUES ('Employee')");
            Sql("INSERT INTO UserTypes (Name) VALUES ('Employer')");
        }
        
        public override void Down()
        {
        }
    }
}
