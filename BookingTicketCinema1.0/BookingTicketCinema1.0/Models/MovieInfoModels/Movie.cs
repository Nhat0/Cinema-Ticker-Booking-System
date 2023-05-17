

using BookingTicketCinema1._0.Models.MovieInfoModels;

namespace BookingTicketCinema1._0.Models.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public int Runtime { get; set; }
        public string? Poster_Path { get; set; }
        public DateTime Release_Date { get; set; }
        public float? Vote_Average { get; set; }
        public int Vote_Count { get; set; }
        public List<Genre> Genres{ get; set; }
        public string? Backdrop_Path { get; set; }
       public string? Trailer_Path { get; set; }
        public List<Screening> Screenings { get; set; }
    }
}
