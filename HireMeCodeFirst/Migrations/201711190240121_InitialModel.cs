namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        BusinessIndustryId = c.Int(nullable: false),
                        EstablishmentDate = c.DateTime(nullable: false),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessIndustries", t => t.BusinessIndustryId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.BusinessIndustryId);
            
            CreateTable(
                "dbo.BusinessIndustries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeId = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobPostings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        JobTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        JobLocationId = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        JobTitle = c.String(),
                        JobDescription = c.String(),
                        NumOpenings = c.Int(nullable: false),
                        HoursPerWeek = c.Int(nullable: false),
                        WageSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Qualifications = c.String(),
                        ApplicationInstructions = c.String(),
                        ApplicationWebsite = c.String(),
                        PostingDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        NumViews = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Id)
                .ForeignKey("dbo.JobLocations", t => t.JobLocationId, cascadeDelete: true)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.JobTypeId)
                .Index(t => t.JobLocationId)
                .Index(t => t.UserAccountId);
            
            CreateTable(
                "dbo.JobLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.JobPostings", "UserAccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.JobPostings", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.JobPostings", "JobLocationId", "dbo.JobLocations");
            DropForeignKey("dbo.JobLocations", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.JobPostings", "Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Companies", "BusinessIndustryId", "dbo.BusinessIndustries");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobLocations", new[] { "CompanyId" });
            DropIndex("dbo.JobPostings", new[] { "UserAccountId" });
            DropIndex("dbo.JobPostings", new[] { "JobLocationId" });
            DropIndex("dbo.JobPostings", new[] { "JobTypeId" });
            DropIndex("dbo.JobPostings", new[] { "Id" });
            DropIndex("dbo.UserAccounts", new[] { "UserTypeId" });
            DropIndex("dbo.Companies", new[] { "BusinessIndustryId" });
            DropIndex("dbo.Companies", new[] { "Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JobTypes");
            DropTable("dbo.JobLocations");
            DropTable("dbo.JobPostings");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.BusinessIndustries");
            DropTable("dbo.Companies");
        }
    }
}
