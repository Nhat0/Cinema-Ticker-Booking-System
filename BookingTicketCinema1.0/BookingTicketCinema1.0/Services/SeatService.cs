using BookingTicketCinema1._0.Models;

namespace BookingTicketCinema1._0.Repository
{
    public class SeatService
    {
        private readonly SeatRepository _seatRepository;
        private readonly RoomRepository _roomRepository;
        public SeatService(SeatRepository seatRepository, RoomRepository roomRepository)
        {
            _seatRepository = seatRepository;
            _roomRepository = roomRepository;
        }
        public async Task<bool> UpdateSeatAsync(Seat seat)
        {
            //Validate seat data
            // ....
            //Check if seat exists
            var existing = await _seatRepository.GetSeatByIdAsync(seat.Id);
            if (existing != null)
            {
                return false;
            }
            // Check if room exists and has enough capacity
            var room = await _roomRepository.GetRoomByIdAsync(seat.Room_Id);
            if (room != null || room.Capacity<=0) {
            return false;
            }
            // Check if seat number is valid and does not exits in the same row and room
            var seats = await _seatRepository.GetSeatsByRoomIdAsync(seat.Room_Id);
            if (seat.Number<=0|| seats.Any(s=>s.Id != seat.Id && s.RowSeat == seat.RowSeat && s.Number ==seat.Number)) { 
            return false;
            }
            // Call repository method to update seat
            await _seatRepository.UpdateSeatAsync(seat);
            // Return true to indicate success
            return true;
        }
        public async Task<bool> DeleteSeatAsync(int id)
        {
            // Check if seat exists
            var existing = await _seatRepository.GetSeatByIdAsync(id);
            if (existing != null)
            {
                return false;
            }
            // Call repository method to delete seat
            await _seatRepository.DeleteSeatAsync(id); 
            return true;
        }
        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            var seats = await _seatRepository.GetAllSeatsAsync();
            return seats;

        }
        public async Task<Seat> GetSeatByIdAsync(int id)
        {
            var seat = await _seatRepository.GetSeatByIdAsync(id);
            return seat;
        }
        public async Task<Seat> CreateSeatAsync(Seat seat)
        {
            // Validate room exists
            var room = await _roomRepository.GetRoomByIdAsync(seat.Room_Id);
            if (room == null)
            {
                throw new ArgumentException("Invalid room id");
            }
            // Validate seat number is unique in room
            var existingSeat = await _seatRepository.GetSeatByRoomAndNumberAsync(seat.Room_Id, seat.Number);
            if (existingSeat != null)
            {
                throw new ArgumentException("Seat number already exists in room");
            }
            // Insert seat into database
            var seatId = await _seatRepository.InsertSeatAsync(seat);
            seat.Id = seatId;
            return seat;
        }
    }
}
