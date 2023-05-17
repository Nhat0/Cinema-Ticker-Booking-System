
using BookingTicketCinema1._0.Models.MovieInfoModels;
using BookingTicketCinema1._0.Models.Movies;
using BookingTicketCinema1._0.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookingTicketCinema1._0.Services.MovieInfoService
{
    public class MovieService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public MovieService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["e880b4685229764e6a36b08769d2eae0"];
        }
        public async Task<List<Movie>> GetMoviesAsync(string query)
        {
            var response = await
            _client.GetAsync("https://api.themoviedb.org/3/movie/now_playing" +
            "?api_key=e880b4685229764e6a36b08769d2eae0&language=en&region=VN");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieResult>(content);
            var movies = new List<Movie>();
            foreach (var movie in result.Results)
            {
                var details = await GetMovieAsync(movie.Id); 
                movie.Runtime = details.Runtime;
                movie.Trailer_Path = await GetTrailerPathAsync(movie.Id);
               
                movies.Add(movie);
            }
            return movies;

        }
        public async Task<Movie> GetMovieAsync(int movieId)
        {
            var response = await _client.GetAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key=e880b4685229764e6a36b08769d2eae0&append_to_response=genres");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Movie>(content);
            return result;
        }
        private async Task<string> GetTrailerPathAsync(int movieId)
        {
            var response = await _client.GetAsync($"https://api.themoviedb.org/3/movie/{movieId}/videos?api_key=e880b4685229764e6a36b08769d2eae0");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VideoResult>(content);
            var videos = result.Results;
            var trailer = videos.FirstOrDefault(v => v.Type == "Trailer" && v.Site == "YouTube");
            if (trailer != null)
            {
                return $"https://www.youtube.com/watch?v={trailer.Key}";
            }
            else
            {
                return null;
            }
        }

    }
}
