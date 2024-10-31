
namespace Model.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public Province Province { get; set; }
        public int ProvinceId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
