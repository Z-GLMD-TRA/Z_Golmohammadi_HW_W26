
namespace Model.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public Province Province { get; set; }
        public int ProvinceId { get; set; }
    }
}
