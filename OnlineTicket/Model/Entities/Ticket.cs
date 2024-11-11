
namespace Model.Entities
{
    public class Ticket : BaseEntity<Guid>
    {
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
        public string TicketNumber { get; set; }
        public int TicketCount{ get; set; }
        public DateTime BuyDate { get; set; }

        //public User User { get; set; }
        //public Guid UserId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public static string NewTicketNumber()
        {
            var random = new Random();
            var res = random.Next(10001, 99999).ToString();
            return res;
        }
    }

}
