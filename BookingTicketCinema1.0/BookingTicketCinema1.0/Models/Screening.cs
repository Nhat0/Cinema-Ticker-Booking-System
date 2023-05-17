namespace BookingTicketCinema1._0.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public int Movie_Id { get; set; }
        public int Room_Id { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public decimal Price { get; set; }

    }
}
