namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCompanies1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO JobLocations (CompanyId, Address1, Address2, City, State, Zip, Country) VALUES (1, '1200 E 151st St', '', 'Olathe', 'KS', '66062', 'USA')");
        }
        
        public override void Down()
        {
        }
    }
}
