using BookingTicketCinema1._0.Models;
using Dapper;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Data;

namespace BookingTicketCinema1._0.Repository
{
    public class SeatRepository
    {
        private readonly IDbConnection _connection;
        public SeatRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> InsertSeatAsync(Seat seat)
        {
            var mySql = @"Insert Into Seat(Room_Id,Row, Number) VALUES(@room_id,@row,@number);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await _connection.QuerySingleAsync<int>(mySql, seat);
            return id;
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            var mySql = @"SELECT *FROM seats";
            return await _connection.QueryAsync<Seat>(mySql);
        }
        //Get Seat id
        public async Task<Seat> GetSeatByIdAsync(int id)
        {
            var mySql = @"SELECT * FROM seats WHERE Id = @id";
            var seat = await _connection.QuerySingleOrDefaultAsync<Seat>(mySql, new { Id = id });
            return seat;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByRoomIdAsync (int roomId)
        {
            var mySql = @"SELECT * FROM seats WHERE Room_Id = @room_id";
            var seats = await _connection.QueryAsync<Seat>(mySql, new {Room_Id = roomId}); 
            return seats;
        }
        public async Task<bool> UpdateSeatAsync(Seat seat)
        {
            var mySql = @"UPDATE seats SET Room_Id = @room_id,Row=@row, Number = @number
                        WHERE Id = @id";
            var rowsAffected = await _connection.ExecuteAsync(mySql, seat);
            return rowsAffected > 0;

        }
        public async Task<int> DeleteSeatAsync(int seatId)
        {
            var mySql = @" DELETE FROM seats where Id = @id";
            return await _connection.ExecuteAsync(mySql,new {Id = seatId});
        }
        public async Task<Seat> GetSeatByRoomAndNumberAsync(int roomId, int seatNumber)
        {
            var sql = @"SELECT * FROM seats WHERE Room_Id = @room_id AND Number = @number";
            var seat = await _connection.QuerySingleOrDefaultAsync<Seat>(sql, new { RoomId = roomId, SeatNumber = seatNumber });
            return seat;
        }
    }
}
