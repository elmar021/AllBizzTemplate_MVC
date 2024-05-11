using AllBizz.Business.DTOs.SliderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.DTOs.ServiceDtos
{
    public class ServiceCreateDto
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.LogoUrl)
                .NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Description)
                .NotEmpty().NotNull().MaximumLength(50);

            
        }
    }
}
