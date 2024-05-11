using AllBizz.Business.DTOs.CategoryDtos;
using AllBizz.Business.DTOs.ProfessionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDto dto);
        Task Update(CategoryUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<List<CategoryGetDto>> GetAllAsync();
    }
}
