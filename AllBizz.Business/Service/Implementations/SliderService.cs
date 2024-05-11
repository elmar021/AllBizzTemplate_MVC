using AllBizz.Business.DTOs.SliderDtos;
using AllBizz.Business.Extension;
using AllBizz.Business.Service.Interfaces;
using AllBizz.Core.Entities;
using AllBizz.Core.Repository.Interfaces;
using AllBizz.Data.DAL;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.Service.Implementations
{

    public class SliderService : ISliderService
    {
        private readonly AppDbContext _appDb;
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _webHost;
        private readonly IMapper _mapper;

        public SliderService(AppDbContext appDb,ISliderRepository sliderRepository,IWebHostEnvironment webHost,IMapper mapper)
        {
            _appDb = appDb;
            _sliderRepository = sliderRepository;
            _webHost = webHost;
            _mapper = mapper;
        }
        public async Task Create(SliderCreateDto slider)
        {
            var newSlid = new Slider();
            if(slider.FormFile.FileName != null)
            {

                if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (slider.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }
                newSlid = _mapper.Map<Slider>(slider);
                newSlid.ImageUrl = Helper.SaveFile(_webHost.WebRootPath, "Uploads/Sliders", slider.FormFile);             
            }

            await _sliderRepository.CreateAsync(newSlid);
            await _sliderRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Slider slider =await _sliderRepository.GetByIdAsync(x=>x.Id == id);
            if (slider != null)
            {

                if (!string.IsNullOrEmpty(slider.ImageUrl))
                {
                    if (System.IO.File.Exists(slider.ImageUrl))
                    {
                        System.IO.File.Delete(slider.ImageUrl);
                    }
                }
                _sliderRepository.Delete(slider);
                await _sliderRepository.CommitAsync();
            }
             
        }

        public async Task<List<SliderGetDto>> GetAllAsync()
        {
            var sliders = await _sliderRepository.GetAllAsync();
            var slid = sliders.Select(x => new SliderGetDto()
            {
                Title = x.Title,
                Desc =x.Desc,
                ButtonText = x.ButtonText,
                VideoUrl = x.VideoUrl,
                ImageUrl = x.ImageUrl,
            }).ToList();
            return slid;
        }

        public async Task<SliderGetDto> GetByIdAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(x=>x.Id == id);
            var slid = _mapper.Map<SliderGetDto>(slider);
            return slid;
        }

        public async Task SoftDelete(int id)
        {
            Slider slider = await _sliderRepository.GetByIdAsync(x => x.Id == id);
            if (slider != null)
            {
                slider.IsDeleted = !slider.IsDeleted;
                await _sliderRepository.CommitAsync();
            }
        }

        public async Task Update(SliderUpdateDto slider)
        {
            var slid = await _sliderRepository.GetByIdAsync(x=>x.Id == slider.Id);
            if (slid != null)
            {

                if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (slider.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Sliders", slid.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                slid.ImageUrl = Helper.SaveFile(_webHost.WebRootPath, "Uploads/Sliders", slider.FormFile);
            }

                slid.Title = slider.Title;
                slid.Desc = slider.Desc;
                slid.ButtonText = slider.ButtonText;
                await _sliderRepository.CommitAsync();
            }
        }
    }
