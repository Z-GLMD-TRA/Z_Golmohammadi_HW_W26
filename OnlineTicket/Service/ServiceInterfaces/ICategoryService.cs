using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using DataTransferObject.DTOClasses;

namespace Service.ServiceInterfaces
{
    public interface ICategoryService : IBaseService<Category,CategoryDTO,int>
    {
        Task<bool> CreateCategory(CategoryDTO categoryDTO);
        Task<List<CategoryDTO>> GetAllCategories();
    }
}
