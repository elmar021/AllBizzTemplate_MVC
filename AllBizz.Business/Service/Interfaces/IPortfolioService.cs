using AllBizz.Business.DTOs.CategoryDtos;
using AllBizz.Business.DTOs.PortfolioDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface IPortfolioService
    {
        Task Create(PortfolioCreateDto dto);
        Task Update(PortfolioUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<PortfolioGetDto> GetByIdAsync(int id);
        Task<List<PortfolioGetDto>> GetAllAsync();
    }
}
