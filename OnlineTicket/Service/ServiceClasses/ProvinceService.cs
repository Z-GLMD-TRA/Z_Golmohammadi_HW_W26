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
    public class ProvinceService : IProvinceService
    {
        private readonly IBaseRepository<Province, int> _repository;

        public ProvinceService(IBaseRepository<Province, int> repository)
        {
            _repository = repository;
        }
        public ProvinceDTO TranslateToDTO(Province entity)
        {
            return entity.Adapt<ProvinceDTO>();
        }

        public Province TranslateToEntity(ProvinceDTO dto)
        {
            return dto.Adapt<Province>();
        }

        public async Task<bool> CreateProvince(ProvinceDTO provinceDTO)
        {
            var entity = TranslateToEntity(provinceDTO);
            var result = await _repository.CreateDataAsync(entity);
            return result != null;

        }

        public async Task<List<ProvinceDTO>> GetAllProvinces()
        {
            var provinces = await _repository.GetAllAsync();
            var provinceDTO = provinces.ProjectToType<ProvinceDTO>().ToList();
            return provinceDTO;
        }
    }
}
