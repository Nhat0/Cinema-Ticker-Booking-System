using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingTicketCinema1._0.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ScreeningsController:ControllerBase
    {
        private readonly ScreeningService _screeningService;
        public ScreeningsController(ScreeningService screeningService)
        {
            _screeningService = screeningService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Screening screening)
        {
            try
            {
                var id = await _screeningService.CreateScreeningAsync(screening);
                return CreatedAtAction(nameof(GetById), new { id = id }, screening);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var screening = await _screeningService.GetScreeningByIdAsync(id);
            if(screening == null)
            {
                return NotFound();
            }
            return Ok(screening);
        }
        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetByMovie(int movieId)
        {
            var screenings = await _screeningService.GetScreeningsByMovieAsync(movieId);
            return Ok(screenings);
        }
    }
}
