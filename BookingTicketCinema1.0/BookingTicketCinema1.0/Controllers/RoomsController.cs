using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Repository;
using BookingTicketCinema1._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingTicketCinema1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController: ControllerBase
    {
        private readonly RoomService _roomService;
        private readonly RoomRepository _roomRepository;
        public RoomsController(RoomService roomService , RoomRepository roomRepository)
        {
            _roomService = roomService;
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }
 
    }

}
