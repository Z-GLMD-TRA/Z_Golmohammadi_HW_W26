
namespace Model.Entities
{
    public class Province : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
