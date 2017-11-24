namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateJobType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO JobTypes (Name) VALUES ('Full-Time')");
            Sql("INSERT INTO JobTypes (Name) VALUES ('Part-Time')");
            Sql("INSERT INTO JobTypes (Name) VALUES ('Temporary')");
            Sql("INSERT INTO JobTypes (Name) VALUES ('Internship')");
        }
        
        public override void Down()
        {
        }
    }
}
