using Microsoft.AspNetCore.Identity;

namespace Model.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string RolePersianName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        public int RoleStatusId { get; set; }
    }
}