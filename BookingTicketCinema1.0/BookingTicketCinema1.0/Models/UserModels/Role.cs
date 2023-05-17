namespace BookingTicketCinema1._0.Models.UserModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<UserRole> UserRoles { get; set;}
    }
}
