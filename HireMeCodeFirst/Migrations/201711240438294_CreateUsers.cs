namespace HireMeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6fdc01ed-399b-4b19-9e96-ab5b956d9cbf', N'admin@HireMe.com', 0, N'AEvYmld7eg7JQR/Lq7OXw4VQjeMU/W9yZJcK++B2Sbp459cjFdEOrW8SqxXxkBwkJQ==', N'289eee03-3643-4201-853c-dc35990080b8', NULL, 0, 0, NULL, 1, 0, N'admin@HireMe.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b041c73e-7f3c-414d-ab22-e339e45192d6', N'employee@HireMe.com', 0, N'AKpoveuSK+xjwyHIVxlSAdelHZZIJ7d4DbR+YXGA5RE5fHOC/WSQ/LvUIs7ott7JKQ==', N'ec857fcc-7df8-4e00-89e9-d3dee35efdc7', NULL, 0, 0, NULL, 1, 0, N'employee@HireMe.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c113dfd1-de69-41c7-8c27-ee04878826d3', N'CanManagePostings')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6fdc01ed-399b-4b19-9e96-ab5b956d9cbf', N'c113dfd1-de69-41c7-8c27-ee04878826d3')
                
            ");
        }
        
        public override void Down()
        {
        }
    }
}
