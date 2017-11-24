namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCompanies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Companies (Id, UserAccountId, Name, Description, BusinessIndustryId, EstablishmentDate, Website) VALUES (1, 2, 'Garmin', 'Engineering Firm', 14, 10/01/1989, 'www.garmin.com')");
        }
        
        public override void Down()
        {
        }
    }
}
