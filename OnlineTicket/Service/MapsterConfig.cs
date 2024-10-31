using DataTransferObject.DTOClasses;
using Mapster;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class MapsterConfig
    {
        public static void RegisterMapping()
        {
            //TypeAdapterConfig<Role, RoleDTO>.NewConfig().Map(x => x.RoleDescription, y => y.Description);

            TypeAdapterConfig<User, UserDTO>.NewConfig()
                .Map(x => x.Email, y => y.UserName);
            TypeAdapterConfig<UserDTO, User>.NewConfig()
                .Map(x => x.UserName, y => y.Email);

            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                .Map(x => x.Name, y => y.CategoryName);
            TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
                .Map(x => x.CategoryName, y => y.Name);
        }
    }
}
