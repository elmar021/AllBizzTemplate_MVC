using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Business.DTOs.MemberDtos
{
    public class MemberCreateDto
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }

    public class MemberCreateValidator : AbstractValidator<MemberCreateDto>
    {
        public MemberCreateValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.InstaUrl)
                .NotEmpty()
                .MaximumLength(50);

            

            RuleFor(x => x.TwitUrl)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.FaceUrl)
                .NotEmpty()
                .MaximumLength(50);

            
        }
    }

}
