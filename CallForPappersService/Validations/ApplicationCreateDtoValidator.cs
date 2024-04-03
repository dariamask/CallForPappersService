using CallForPappersService.Data.Dto;
using FluentValidation;

namespace CallForPappersService.Validations
{
    public class ApplicationCreateDtoValidator : AbstractValidator<ApplicationCreateDto>
    {
        public ApplicationCreateDtoValidator() 
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x =>  x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Outline).NotEmpty().MaximumLength(1000);          
        }
    }
}
