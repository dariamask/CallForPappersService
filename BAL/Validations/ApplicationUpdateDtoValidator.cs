
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
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Outline).NotEmpty().MaximumLength(1000); 
        }
    }
}
