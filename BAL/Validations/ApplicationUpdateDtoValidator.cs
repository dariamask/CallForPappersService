using CallForPappersService_BAL.Dto;
using FluentValidation;

namespace CallForPappersService_BAL.Validations
{
    public class ApplicationUpdateDtoValidator : AbstractValidator <ApplicationUpdateDto>
    {
        public ApplicationUpdateDtoValidator() 
        {
            RuleFor(dto => dto).Must(HaveAtLeastOneNonNullProperty)
                .WithMessage("At least one property must be set except AuthorId");

            RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name is not null);
            RuleFor(x => x.Description).MaximumLength(300).When(x => x.Description is not null);
            RuleFor(x => x.Outline).MaximumLength(1000).When(x => x.Outline is not null);
        }

        private bool HaveAtLeastOneNonNullProperty(ApplicationUpdateDto dto)
        {
            return dto.Name != null || dto.Description != null || dto.Outline != null;
        }
    }
}
