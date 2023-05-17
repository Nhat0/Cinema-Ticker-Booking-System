using BookingTicketCinema1._0.Models.Movies;
using BookingTicketCinema1._0.Repository;
using BookingTicketCinema1._0.Services.MovieInfoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System.Net.Http;

namespace BookingTicketCinema1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;
        private readonly MovieRepository _movieRepository;
        private readonly HttpClient _client;
        public MovieController(MovieService movieService, MovieRepository movieRepository)
        {
            _movieService = movieService;
            _movieRepository = movieRepository;
          


        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string query)
        {
            
            var movies = await _movieService.GetMoviesAsync(query);
            
            foreach (var movie in movies)
            {
                movie.Poster_Path = "https://image.tmdb.org/t/p/w500" + movie.Poster_Path;
                movie.Backdrop_Path = "https://image.tmdb.org/t/p/w500" + movie.Backdrop_Path;
                //var genres = await _movieService.GetGenresAsync(movie.Id);
                //movie.Genres = genres;
                await _movieRepository.InsertMovieAsync(movie);   
            }
            return Ok(movies.Count);
    
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return Ok(movies);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieRepository.DeleteMovieAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
     
    

    }
}

