namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieStockToByte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Stock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
    }
}
