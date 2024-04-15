using FluentValidation;
using CallForPappersService_BAL.Dto;

namespace CallForPappersService_BAL.Validations
{
    public class ApplicationCreateDtoValidator : AbstractValidator<ApplicationCreateDto>
    {
        public ApplicationCreateDtoValidator()
        {
            RuleFor(dto => dto).Must(HaveAtLeastOneNonNullProperty)
             .WithMessage("At least one property must be set except AuthorId");

            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).When(x => x.Name is not null);
            RuleFor(x => x.Description).MaximumLength(300).When(x => x.Description is not null);
            RuleFor(x => x.Outline).NotEmpty().MaximumLength(1000).When(x => x.Outline is not null);
        }

        private bool HaveAtLeastOneNonNullProperty(ApplicationCreateDto dto)
        {
            return dto.Name != null || dto.Description != null || dto.Outline != null;
        }
    }
}
            
