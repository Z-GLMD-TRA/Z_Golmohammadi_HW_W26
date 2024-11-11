using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataTransferObject.DTOClasses
{
    public class ProvinceDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();

    }
}
