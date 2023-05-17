using BookingTicketCinema1._0.Models;
using Dapper;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Data;

namespace BookingTicketCinema1._0.Repository
{
    public class RoomRepository
    {
        private readonly IDbConnection _connection;
        public RoomRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var sql = @"SELECT * FROM rooms";
            var rooms = await _connection.QueryAsync<Room>(sql);
            return rooms;
        }
        public async Task<int> InsertRoomAsync(Room room)
        {
            var mySql = @"INSERT INTO room(Name, Capacity) VALUES(@name, @capacity);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await _connection.QuerySingleAsync<int>(mySql, room);
            return id;
        }
        //get room by id
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            using (_connection)
            {
                _connection.Open();
                var mySql = @"SELECT * FROM rooms WHERE Id= @id";
                var room = await _connection.QuerySingleOrDefaultAsync<Room>(mySql, new { Id = id });
                return room;
            }
        }

        public async Task<Room> GetRoomByNameAsync(string name)
        {
            var sql = @"SELECT * FROM rooms WHERE Name = @name";
            var room = await _connection.QuerySingleOrDefaultAsync<Room>(sql, new { Name = name });
            return room;
        }

        public async Task<bool> UpdateRoomAsync(Room room)
        {
            var sql = @"UPDATE rooms SET Name = @name, Capacity = @capacity WHERE Id = @id";
            var result = await _connection.ExecuteAsync(sql, room);
            return result > 0;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var sql = @"DELETE FROM rooms WHERE Id = @id";
            var result = await _connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    
    }
}
