using Microsoft.AspNetCore.Identity;

namespace Model.Entities
{
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// First name of user
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Last name of user
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Email of user
        /// </summary>
       // public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Phone of user
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// User's birth date
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Check this user is enable or not
        /// </summary>
        public bool IsActived { get; set; }

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
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Address> Addresses { get; set; }

        //public int BlobId { get; set; }
        //public Blob Blob { get; set; }
    }
}
