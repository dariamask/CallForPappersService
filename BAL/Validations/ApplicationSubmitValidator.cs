using CallForPappersService_BAL.Dto;
using CallForPappersService_DAL.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallForPappersService_BAL.Validations
{
    public class ApplicationSubmitValidator : AbstractValidator<ApplicationSubmitDto>
    {
        public ApplicationSubmitValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().When(m => m.Name != null);
            RuleFor(x => x.Outline).NotEmpty().When(m => m.Outline != null);
        }
    }
}
