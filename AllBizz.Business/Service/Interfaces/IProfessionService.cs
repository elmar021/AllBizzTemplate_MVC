using AllBizz.Business.DTOs.ProfessionDtos;
using AllBizz.Business.DTOs.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface IProfessionService
    {
        Task Create(ProfessionCreateDto dto);
        Task Update(ProfessionUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<ProfessionGetDto> GetByIdAsync(int id);
        Task<List<ProfessionGetDto>> GetAllAsync();
    }
}
