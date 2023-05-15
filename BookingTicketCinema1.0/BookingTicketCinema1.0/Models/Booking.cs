namespace BookingTicketCinema1._0.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public int SeatId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; } // pending, confirmed or cancelled
    }
}
