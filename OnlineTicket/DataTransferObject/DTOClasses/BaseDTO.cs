using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses
{
    public class BaseDTO<KeyTypeId>
    {
        public KeyTypeId Id { get; set; }

        public DateTime EditedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CreatorId { get; set; }
        public Guid EditorId { get; set; }
    }
}
