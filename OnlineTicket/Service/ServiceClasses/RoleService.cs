using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Model.Entities;
using Service.ServiceInterfaces;

namespace Service.ServiceClasses
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public RoleDTO TranslateToDTO(Role entity)
        {
            return entity.Adapt<RoleDTO>();
        }

        public Role TranslateToEntity(RoleDTO dto)
        {
            return dto.Adapt<Role>();
        }

        public async Task<RoleDTO> GetRole(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var data = TranslateToDTO(role);
            return data;
        }

        public async Task<RoleDTO> CreateRole(RoleDTO roleDTO)
        {
            var role = TranslateToEntity(roleDTO);
            await _roleManager.CreateAsync(role);
            return roleDTO;
        }
    }
}
