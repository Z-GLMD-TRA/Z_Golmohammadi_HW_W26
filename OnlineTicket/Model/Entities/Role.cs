using Microsoft.AspNetCore.Identity;

namespace Model.Entities
{
    public class Role : IdentityRole<Guid>
    {
        /// <summary>
        /// name of role
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// persian name of role
        /// </summary>
        public string PersianName { get; set; } = string.Empty;
        /// <summary>
        /// Description of role
        /// </summary>
        public string Description { get; set; } = string.Empty;

        // Relations
        public ICollection<User> Users { get; set; } = new List<User>();



        //BaseEntity
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// Date and time of editing data in the system
        /// </summary>
        public DateTime EditedDateTime { get; set; }
        /// <summary>
        /// The user ID of the creator of the data
        /// </summary>
        public Guid? CreatorUserId { get; set; }
        /// <summary>
        /// The user ID of the data editor
        /// </summary>
        public Guid? EditorUserId { get; set; }
        /// <summary>
        /// The navigation property of user for the data of creator user
        /// </summary>
        public User? CreatorUser { get; set; }
        /// <summary>
        /// The navigation property of user for the data of editor user
        /// </summary>
        public User? EditorUser { get; set; }
    }
}