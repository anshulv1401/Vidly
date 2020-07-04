namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAvailableColumnAddedInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "Stock");
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
