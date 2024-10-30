using Model.Entities;

namespace Model
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }

        public DateTime EditedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CreatorId { get; set; }
        public Guid EditorId { get; set; }

        public User Creator { get; set; }
        public User Editor { get; set; }
    }
}
