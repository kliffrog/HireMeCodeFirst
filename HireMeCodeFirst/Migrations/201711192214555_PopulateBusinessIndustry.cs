namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBusinessIndustry : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Accounting')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Advertising/Marketing')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Aerospace')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Agriculture')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Architecture/Urban Planning')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Arts')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Automotive')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Banking')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Biotech/Pharmaceuticals')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Business Services')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Chemicals')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Communications/Media')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Computer Information Systems')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Computers')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Construction')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Consulting')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Consumer Products')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Cosmetology')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Education')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Electronics')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Energy')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Engineering')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Entertainment')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Entrepreneurial/Start-Ups')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Environment')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Fashion')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Financial Services')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Food Science')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Food Services')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Forestry')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Government/Public Admin')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Health Information Systems')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Hotel/Restaurant/Hospitality')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Housing/Urban Development')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Information Technology-Network')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Insurance')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Interior Design')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('International Affairs')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Internet')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Investment Banking')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Law')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Law Enforcement/Security')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Manufacturing')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Maritime')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Military/Defense')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Mining')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Museums/Libraries')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Natural Resources')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Non-Profit/Philanthropy')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Other')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Parks and Camps')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Print/Publishing')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Railroad')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Real Estate')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Religion')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Retail/Wholesale')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Rubbers/Plastics')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Sciences')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Sports/Recreation')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Staffing/Executive Search')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Telecommunications')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Tobacco')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Trade')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Transportation')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Travel/Tourism')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Unspecified')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Utilities')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Venture Capital/Investing')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Veterinary')");
            Sql("INSERT INTO BusinessIndustries (Name) VALUES ('Waste Management')");
        }
        
        public override void Down()
        {
        }
    }
}
