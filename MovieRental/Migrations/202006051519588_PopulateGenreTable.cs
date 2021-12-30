namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreType) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Romance')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Thriller')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Sci Fi')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Adventure')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
