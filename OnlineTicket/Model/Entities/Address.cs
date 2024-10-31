
namespace Model.Entities
{
    public class Address : BaseEntity<int>
    {
        public string Description { get; set; }
        public string PostalCode { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
        public Province Province { get; set; }
        public int ProvinceId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
