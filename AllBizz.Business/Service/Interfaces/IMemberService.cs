using AllBizz.Business.DTOs.MemberDtos;
using AllBizz.Business.DTOs.ProfessionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Interfaces
{
    public interface IMemberService
    {
        Task Create(MemberCreateDto dto);
        Task Update(MemberUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<MemberGetDto> GetByIdAsync(int id);
        Task<List<MemberGetDto>> GetAllAsync();
    }
}
