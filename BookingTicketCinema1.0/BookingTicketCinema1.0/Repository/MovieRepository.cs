
using BookingTicketCinema1._0.Models.MovieInfoModels;
using BookingTicketCinema1._0.Models.Movies;
using BookingTicketCinema1._0.Services.MovieInfoService;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Data;
using System.Xml.Linq;


namespace BookingTicketCinema1._0.Repository
{
    public class MovieRepository
    {
        private readonly IDbConnection _connection;
        private readonly MovieService _movieService;
        public MovieRepository(IDbConnection connection, MovieService movieService)
        {
            _connection = connection;
            _movieService = movieService;
        }
        public async Task<int> InsertMovieAsync(Movie movie)
        {
            using (_connection)
            {
                _connection.Open();
             
                var mySql = @"INSERT INTO movie (ID, Title,Overview, Poster_Path, Release_Date, Vote_Average, Vote_Count ,Backdrop_Path,Trailer_Path )
                                           VALUES(@id,  @title, @overView, @poster_path , @release_date, @vote_average, @vote_count, @backdrop_path,@trailer_path);";
                await _connection.ExecuteAsync(mySql, movie);

                 return 1;
               

            }

        }
        public async Task InsertGenresAsync(int movieId, List<Genre> genres)
        {
            var sql = @"INSERT INTO genre (id, name) VALUES (@id, @name);
                    INSERT INTO movie_genre (movie_id, genre_id) VALUES (@movieId, @genreId);";
            foreach (var genre in genres)
            {
                await _connection.ExecuteAsync(sql, new { Id = genre.Id, Name = genre.Name, MovieId = movieId });
            }
        }


        //public async Task<int> InsertGenresAsync(List<Genre> genres)
        //{
        //    var mySql = @"INSERT INTO genre (Id, Name) VALUES (@id, @name);";
        //    var rows = await _connection.ExecuteAsync(mySql, genres);
        //    return rows;
        //}

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            using (_connection)
            {
                _connection.Open();
                var mySql = "SELECT * FROM movie";
                var movies = await _connection.QueryAsync<Movie>(mySql);
                return movies;
            }
        }
        public async Task<int> DeleteMovieAsync(int id)
        {
            using (_connection)
            {
                _connection.Open();
                var mySql = @"DELETE FROM movie WHERE Id = @Id";
                var result = await _connection.ExecuteAsync(mySql, new { Id = id });
                return result;
            }
        }


    }
}
