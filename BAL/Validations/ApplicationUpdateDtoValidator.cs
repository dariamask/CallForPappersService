
using CallForPappersService_BAL.Dto;
using CallForPappersService_DAL.Data.Entities;
using FluentValidation;
using System.Data;
using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Validations
{
    public class ApplicationUpdateDtoValidator : AbstractValidator <ApplicationUpdateDto>
    {
        public ApplicationUpdateDtoValidator() 
        {
            RuleFor(x => x.Name).MaximumLength(100).NotEmpty().When(x => x.Name is not null);
            RuleFor(x => x.Description).MaximumLength(300).NotEmpty().When(x => x.Description is not null);
            RuleFor(x => x.Outline).MaximumLength(1000).NotEmpty().When(x => x.Outline is not null); 
        }
    }
}
