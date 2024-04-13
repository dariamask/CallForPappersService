using CallForPappersService_DAL.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallForPappersService_BAL.Validations
{
    internal class ApplicationSubmitValidator : AbstractValidator<Application>
    {
        public ApplicationSubmitValidator() 
        { 
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Outline).NotEmpty();
        }
    }
}
