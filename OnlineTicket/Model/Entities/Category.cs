using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; } = string.Empty;

        public ICollection<Ticket> Tickets { get; set; }

    }
}
