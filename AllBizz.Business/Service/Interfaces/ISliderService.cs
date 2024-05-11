using AllBizz.Business.DTOs.SliderDtos;
using AllBizz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface ISliderService
    {
        Task Create(SliderCreateDto dto);
        Task Update(SliderUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<SliderGetDto> GetByIdAsync(int id);
        Task<List<SliderGetDto>> GetAllAsync();

    }
}
