using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using FluentValidation;
using System.Data;
using System.Text.Json.Serialization;

namespace CallForPappersService.Validations
{
    public class ApplicationUpdateDtoValidator : AbstractValidator <ApplicationUpdateDto>
    {
        public ApplicationUpdateDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Outline).NotEmpty().MaximumLength(1000); 
        }
    }
}
