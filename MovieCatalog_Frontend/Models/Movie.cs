namespace MovieCatalog_Frontend.Models
{
    public class Movie
    {
        // this match my backend entity

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Year { get; set; }
        public double Rating {get; set;}
    }
}
