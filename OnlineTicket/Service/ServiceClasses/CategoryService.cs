using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryInterfaces;
using Mapster;
using Model.Entities;
using Service.ServiceInterfaces;

namespace Service.ServiceClasses
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category, int> _repository;

        public CategoryService(IBaseRepository<Category,int> repository)
        {
            _repository = repository;
        }
        public CategoryDTO TranslateToDTO(Category entity)
        {
            return entity.Adapt<CategoryDTO>();
        }

        public Category TranslateToEntity(CategoryDTO dto)
        {
            return dto.Adapt<Category>();
        }

        public async Task<bool> CreateCategory(CategoryDTO categoryDTO)
        {
            var entity = TranslateToEntity(categoryDTO);
            var result = await _repository.CreateDataAsync(entity);
            return result != null;

        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = await _repository.GetAllAsync();
            var categoriesDTO = categories.ProjectToType<CategoryDTO>().ToList();
            return categoriesDTO;
        }
    }
}
