using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PickNTour.Data.Migrations
{
    public partial class seedIdentityRolesAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'788b8068-64a4-4681-9b71-69b9660f53d8', N'User', N'USER', N'695456b1-c6c6-44a5-840f-2ecb8476465c')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'df4e2567-8563-4f6f-b1ac-ee70298b6f58', N'Admin', N'ADMIN', N'8752e0bd-710b-4e46-b0f9-6ee7fca798cd')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e1ee11e5-a60c-4921-b2a5-dcbbce26a225', N'TourGuide', N'TOURGUIDE', N'cfc29574-1631-4ee8-b232-02c7b4b9a18c')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DateOfBirth], [FullName]) VALUES (N'c0ed9d64-46f9-4968-b3a4-88f37279c3fc', N'admin@pickntour.com', N'ADMIN@PICKNTOUR.COM', N'admin@pickntour.com', N'ADMIN@PICKNTOUR.COM', 0, N'AQAAAAEAACcQAAAAEPEayS+7+c5xR/sZiBw9iSfj5ydep7s/CxkMd528HJDmn6Mcc7uO3QxdVe8d9Xmemg==', N'I23JTXL2AIDUIUGU66DOGTNRCOV35GFA', N'8e843523-e820-4a11-92c1-77c3fea89f26', NULL, 0, 0, NULL, 1, 0, N'2020-07-02 00:00:00', N'PickNTour Admin')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c0ed9d64-46f9-4968-b3a4-88f37279c3fc', N'df4e2567-8563-4f6f-b1ac-ee70298b6f58')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
