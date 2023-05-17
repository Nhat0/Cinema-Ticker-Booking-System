using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Repository;
using Dapper;
using System.Data;

namespace BookingTicketCinema1._0.Services
{
    public class ScreeningService
    {
        private readonly ScreeningRepository _screeningRepository;
        private readonly MovieRepository _movieRepository;
        private readonly RoomRepository _roomRepository;
        private readonly IDbConnection _connection;
        public ScreeningService(ScreeningRepository screeningRepository, MovieRepository movieRepository,
                                RoomRepository roomRepository,IDbConnection connection)
        {
            _screeningRepository = screeningRepository;
            _movieRepository = movieRepository;
            _roomRepository = roomRepository;
            _connection = connection;
        }
        public async Task<int> CreateScreeningAsync(Screening screening)
        {
            //Validate Screening data
            if(screening == null)
            {
                throw new ArgumentNullException(nameof(screening));
            }
            if(screening.Movie_Id<=0|| screening.Movie_Id<=0|| screening.Start_Time==default)
            {
                throw new ArgumentException("Invalid screening data");
            }
            //check if movie exists
            var movie = await _movieRepository.GetMovieByIdAsync(screening.Movie_Id);
            if(movie == null)
            {
                throw new InvalidOperationException("Movie not Found");
            }
            //check if room exists
            var room = await _roomRepository.GetRoomByIdAsync(screening.Room_Id);
            if(room == null)
            {
                throw new InvalidOperationException("Room not found");
            }
            //check if start time is valid
            //EX: check if it is in the future and within the working hours
            var now = DateTime.Now;
            var minStartTime = now.Date.AddHours(8);//8 Am
            var maxStartTime = now.Date.AddHours(23);// 23pm
            if(screening.Start_Time < minStartTime|| screening.Start_Time > maxStartTime)
            {
                throw new InvalidOperationException("Start time is invalid");
            }
            //check if there is no conflict with other screenings in the same room
            //EX: check of the screening duration does not overlap with another screening
            var runtime = movie.Runtime;
            var endTime = screening.Start_Time.AddMinutes(runtime);
            var existingScreenings = await
                _screeningRepository.GetScreeningsByRoomAndDateAsync(screening.Room_Id, screening.Start_Time.Date);
            foreach( var existingScreening in existingScreenings)
            {
                var existingMovie = await _movieRepository.GetMovieByIdAsync(existingScreening.Movie_Id);
                var existingRuntime = existingMovie.Runtime;
                var existingEndTime = existingScreening.Start_Time.AddMinutes(existingRuntime);
                if (screening.Start_Time<existingEndTime && existingScreening.Start_Time < endTime)
                {
                    throw new InvalidOperationException("There is a conflict with another screening in the same room");
                }
            }
            return await _screeningRepository.InsertScreeningAsync(screening);
        }
        public async Task<Screening> GetScreeningByIdAsync(int id)
        {
            var mySql = @"SELECT * FROM screening WHERE Id = @id";
            var screening = await _connection.QuerySingleOrDefaultAsync<Screening>(mySql, new { Id = id });
            return screening;
        }
        public async Task<List<Screening>> GetScreeningsByMovieAsync(int movieId)
        {
            var mySql = @"SELECT *FROM screening WHERE Movie_Id = @movie_id";
            var screenings = await _connection.QueryAsync<Screening>(mySql, new {Movie_Id = movieId});
            return screenings.ToList();
        }
    }
}
