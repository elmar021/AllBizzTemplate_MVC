using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.DTOs.SliderDtos
{
    public class SliderUpdateDto
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ButtonText { get; set; }
        public string VideoUrl { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Desc)
                .NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.ButtonText)
                .NotEmpty().NotNull().MaximumLength(100);

            RuleFor(x => x.VideoUrl)
                .NotEmpty().NotNull().MaximumLength(200);
        }
    }
}
