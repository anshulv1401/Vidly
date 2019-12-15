namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Experimental')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Historical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10,'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11,'SciFi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12,'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13,'Western')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14,'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
