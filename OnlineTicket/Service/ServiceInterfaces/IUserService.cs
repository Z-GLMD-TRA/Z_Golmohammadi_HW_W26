using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Service.ServiceInterfaces
{
    public interface IUserService : IBaseService<User,UserDTO,Guid>
    {
        Task<IdentityResult> CreateUser(UserDTO userDTO);
        Task<List<UserDTO>> GetAllUsers();
    }
}
