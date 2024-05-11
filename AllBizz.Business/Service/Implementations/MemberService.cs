using AllBizz.Business.DTOs.MemberDtos;
using AllBizz.Business.DTOs.ProfessionDtos;
using AllBizz.Business.DTOs.SliderDtos;
using AllBizz.Business.Extension;
using AllBizz.Business.Service.Interfaces;
using AllBizz.Core.Entities;
using AllBizz.Core.Repository.Interfaces;
using AllBizz.Data.Migrations;
using AllBizz.Data.Repository.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public MemberService(IMemberRepository memberRepository,IMapper mapper,IWebHostEnvironment webHost)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task Create(MemberCreateDto dto)
        {
            var newMember = new Member();
            if (dto.FormFile != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }
                newMember = _mapper.Map<Member>(dto);
                newMember.ImageUrl = Helper.SaveFile(_webHost.WebRootPath, "Uploads/Members", dto.FormFile);
            }

            await _memberRepository.CreateAsync(newMember);
            await _memberRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var member =await _memberRepository.GetByIdAsync(x=>x.Id == id);
            if (member == null)
            {
                throw new Exception();
            }

            if (!string.IsNullOrEmpty(member.ImageUrl))
            {
                if (System.IO.File.Exists(member.ImageUrl))
                {
                    System.IO.File.Delete(member.ImageUrl);
                }
            }

             _memberRepository.Delete(member);
            await _memberRepository.CommitAsync();
        }

        public async Task<List<MemberGetDto>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            var mb = members.Select(x => new MemberGetDto()
            {
                FaceUrl = x.FaceUrl,
                ImageUrl = x.ImageUrl,
                InstaUrl = x.InstaUrl,
                TwitUrl = x.TwitUrl,
                FullName = x.FullName,
                ProfessionId = x.ProfessionId,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return mb;
        }

        public async Task<MemberGetDto> GetByIdAsync(int id)
        {
            var member = await _memberRepository .GetByIdAsync(x => x.Id == id);
            var mb = _mapper.Map<MemberGetDto>(member);
            return mb;
        }

        public async Task SoftDelete(int id)
        {
            var member = await _memberRepository.GetByIdAsync(x => x.Id == id);
            if (member != null)
            {
                member.IsDeleted = !member.IsDeleted;
                await _memberRepository.CommitAsync();
            }
        }

        public async Task Update(MemberUpdateDto dto)
        {
            var member = await _memberRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (member != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Members", member.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                member.ImageUrl = Helper.SaveFile(_webHost.WebRootPath, "Uploads/Members", dto.FormFile);
            }

            member.FullName = dto.FullName;
            member.InstaUrl = dto.InstaUrl;
            member.TwitUrl = dto.TwitUrl;
            member.FaceUrl = dto.FaceUrl;
            member.ProfessionId = dto.ProfessionId;
            await _memberRepository.CommitAsync();
        }
    }
}
