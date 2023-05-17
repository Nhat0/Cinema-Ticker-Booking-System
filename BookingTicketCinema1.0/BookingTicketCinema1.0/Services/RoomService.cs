using BookingTicketCinema1._0.Models;
using BookingTicketCinema1._0.Repository;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace BookingTicketCinema1._0.Services
{
    public class RoomService
    {

        private readonly RoomRepository _roomRepository;
        private readonly SeatRepository _seatRepository;
        public RoomService(RoomRepository roomRepository, SeatRepository seatRepository)
        {
            _roomRepository = roomRepository;
            _seatRepository = seatRepository;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return rooms;
        }

        
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            return room;
        }
       

    }

    }

