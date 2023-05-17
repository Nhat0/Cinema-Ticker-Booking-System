using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Models.Movies;
using Dapper;
using System.Data;

namespace BookingTicketCinema1._0.Repository
{
    public class ScreeningRepository
    {
        private readonly IDbConnection _connection;
        public ScreeningRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> InsertScreeningAsync(Screening screening)
        {
            var mySql = @"Insert Into screening(Movie_Id, Room_Id, Start_Time, End_Time, Price)
                            VALUES (@movie_id, @room_id, @start_time, @end_time, @price);";
            var id = await _connection.QuerySingleAsync<int>(mySql, screening);
            return id;
        }
        public async Task<List<Screening>> GetScreeningsByMovieIdAsync (int movieId)
        {
            //get all screenings with MovieId equal to movieId from Screenings table
            var mySql = @"SELECT *FROM screening WHERE Movie_Id = @movie_id";
            var screenings = await _connection.QueryAsync<Screening>(mySql,new { Movie_Id = movieId });
            return screenings.ToList();
        }
        public async Task<List<Screening>> GetScreeningsByRoomAndDateAsync(int roomId,DateTime date)
        {
            var mySql = @"SELECT * FROM screening WHERE Room_Id = room_id AND CAST(start_time AS DATE) =@Date";
            var screenings = await _connection.QueryAsync<Screening>(mySql, new { Room_Id = roomId, Date = date });
            return screenings.ToList();
        }
    }
}
