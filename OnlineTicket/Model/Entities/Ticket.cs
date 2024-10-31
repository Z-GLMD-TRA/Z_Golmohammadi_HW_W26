
namespace Model.Entities
{
    public class Ticket : BaseEntity<Guid>
    {
    public string TicketNumber { get; set; }
    public DateTime BuyDate { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public int SeatNumber { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public static string NewTicketNumber()
    {
        var random = new Random();
        var res = random.Next(10001, 99999).ToString();
        return res;
    }
    }
}
