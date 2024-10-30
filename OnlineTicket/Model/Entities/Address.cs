
namespace Model.Entities
{
    public class Address : BaseEntity<int>
    {
        public string Description { get; set; }
        public string PostalCode { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

    }
}
