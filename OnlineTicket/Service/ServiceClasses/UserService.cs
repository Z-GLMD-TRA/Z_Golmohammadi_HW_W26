using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceInterfaces;

namespace Service.ServiceClasses
{

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public UserDTO TranslateToDTO(User entity)
        {
            return entity.Adapt<UserDTO>();
        }

        public User TranslateToEntity(UserDTO dto)
        {
            return dto.Adapt<User>();
        }

        //public async Task<UserDTO> CreateUser(UserDTO userDTO)
        //{
        //    var user = TranslateToEntity(userDTO);
        //    await _userManager.CreateAsync(user);
        //    return userDTO;
        //}

        public async Task<IdentityResult> CreateUser(UserDTO userDTO)
        {
            var data = TranslateToEntity(userDTO);
            data.PasswordHash = _userManager.PasswordHasher.HashPassword(data, userDTO.Password);
            data.Id = Guid.NewGuid();
            data.CreatorUserId = data.Id;
            data.CreatedDateTime = DateTime.Now;
            return await _userManager.CreateAsync(data);
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserDTO> users = data.Any() ? data.Select(TranslateToDTO).ToList() : new List<UserDTO>();
            return users;
        }
    }
}
