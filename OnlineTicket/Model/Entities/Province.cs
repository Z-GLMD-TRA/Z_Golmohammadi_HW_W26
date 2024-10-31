
namespace Model.Entities
{
    public class Province : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
