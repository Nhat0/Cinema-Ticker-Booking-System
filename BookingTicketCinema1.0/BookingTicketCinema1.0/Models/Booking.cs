namespace BookingTicketCinema1._0.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int Screening_Id { get; set; }
        public int Seat_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; } // pending, confirmed or cancelled
    }
}
