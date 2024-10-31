using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.DTOClasses;
using Model.Entities;

namespace Service.ServiceInterfaces
{
    public interface IRoleService : IBaseService<Role,RoleDTO,Guid>
    {
        Task<RoleDTO> GetRole(Guid roleId);
        Task<RoleDTO> CreateRole(RoleDTO roleDTO);
    }
}
