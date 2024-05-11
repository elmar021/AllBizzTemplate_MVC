using AllBizz.Business.DTOs.ServiceDtos;
using AllBizz.Business.DTOs.SliderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface IServicesService
    {
        Task Create(ServiceCreateDto dto);
        Task Update(ServiceUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<ServiceGetDto> GetByIdAsync(int id);
        Task<List<ServiceGetDto>> GetAllAsync();
    }
}
