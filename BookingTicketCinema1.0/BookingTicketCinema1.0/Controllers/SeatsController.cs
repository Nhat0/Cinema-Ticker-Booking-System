using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookingTicketCinema1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly SeatService _seatService;
        public SeatsController(SeatService seatService)
        {
            _seatService = seatService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Call service method to get all seats
            var seats = await _seatService.GetAllSeatsAsync();

            // Return seats
            return Ok(seats);
        }
    }
}
