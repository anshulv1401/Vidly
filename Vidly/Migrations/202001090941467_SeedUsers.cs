namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e7ff2ca-7820-481e-891e-9ec94061b028', N'admin@vidly.com', 0, N'AMPbDv7Plevc6GU7PY5eTzwQdLZnt0ZzyAbp7armA5VZ8Fk5eU15Gsi/j87dQwO/lg==', N'88c4e018-7efb-46f8-8553-17dd9bca7cc4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa76e248-750d-4df1-9890-c30a3dfca127', N'anshulv1401@gmail.com', 0, N'AJO384AEQAJtlUncjMuYJtrYkr5QilsXv4LxMeyjkqVQLnfJGB4BhO3j5fbwDpfhUQ==', N'3034be59-6a5d-498b-9d86-2b8b09ef2c1b', NULL, 0, 0, NULL, 1, 0, N'anshulv1401@gmail.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'39717d46-0f37-4956-9c85-0360fca9ca2d', N'CanManageMovie')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1e7ff2ca-7820-481e-891e-9ec94061b028', N'39717d46-0f37-4956-9c85-0360fca9ca2d')
");
        }
        
        public override void Down()
        {
        }
    }
}
