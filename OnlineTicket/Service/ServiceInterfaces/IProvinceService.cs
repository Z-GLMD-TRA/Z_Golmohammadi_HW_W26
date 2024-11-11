using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using DataTransferObject.DTOClasses;

namespace Service.ServiceInterfaces
{
    public interface IProvinceService : IBaseService<Province,ProvinceDTO,int>
    {
        Task<bool> CreateProvince(ProvinceDTO provinceDTO);
        Task<List<ProvinceDTO>> GetAllProvinces();
    }
}
