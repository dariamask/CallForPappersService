using FluentValidation;
using CallForPappersService_DAL.Data.Entities;
using CallForPappersService_DAL.Repository;
using CallForPappersService_BAL.Validations.Result;
using CallForPappersService_BAL.Dto;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using FluentResults;
using Error = FluentResults.Error;

namespace CallForPappersService_BAL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IValidator<ApplicationCreateDto> _validatorCreate;
        private readonly IValidator<ApplicationUpdateDto> _validatorUpdate;

        public ApplicationService(IApplicationRepository applicationRepository, 
            IActivityRepository activityRepository, 
            IValidator<ApplicationCreateDto> validatorCreate,
            IValidator<ApplicationUpdateDto> validatorUpdate)
        {
            _applicationRepository = applicationRepository;
            _activityRepository = activityRepository;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
        }
       
        public async Task<Result<ApplicationDto>> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            var validationResult = await _validatorCreate.ValidateAsync(dto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(failure => failure.ErrorMessage));
            }

            if (await _applicationRepository.PendingApplicationExistsAsync(dto.AuthorId, cancellationToken))
            {
                return Result.Fail(ApplicationError.PendingAlreadyExist);
            }

            var application = new Application
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name,
                Description = dto.Description,
                Outline = dto.Outline,
                CreatedDate = DateTime.UtcNow,
                SubmitDate = null,
                Status = ApplicationStatus.Pending,
                ActivityType = ActivityType.Discussion
            };
            
            await _applicationRepository.CreateApplicationAsync(application, cancellationToken);

            return new ApplicationDto()
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.ActivityType,          
                Name = application.Name,
                Description = application.Description,
                Outline = application.Outline,
            };
        }

        public async Task<Result<ApplicationDto>> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetApplicationByApplicationIdAsync(applicationId, cancellationToken);

            if (application is null)
            {
                return Result.Fail(ApplicationError.DoesntExist);
            }

            return new ApplicationDto()
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.Type,
                Name = application.Name,
                Description = application.Description,
                Outline = application.Outline,
            };
        }

        public async Task<Result<List<ApplicationDto>>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken)
        {
            var applications = await _applicationRepository.GetUnsubmittedApplicationOlderDateAsync(unsubmittedOlder, cancellationToken);

            return applications.Select(x => new ApplicationDto
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                ActvityTypeName = x.Activity.Type,
                Name = x.Name,
                Description = x.Description,
                Outline = x.Outline,
            }).ToList();
        }

        public async Task<Result<List<ApplicationDto>>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken)
        {
            var applications = await _applicationRepository.GetApplicationsSubmittedAfterDateAsync(submittedAfter, cancellationToken);

            return applications.Select(x => new ApplicationDto
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                ActvityTypeName = x.Activity.Type,
                Name = x.Name,
                Description = x.Description,
                Outline = x.Outline,
            }).ToList();
        }

        public async Task<Result<ApplicationDto>> GetUnsubmittedApplicationAsync(Guid authorId, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetApplicationByAuthorIdAsync(authorId, cancellationToken);

            if (application == null)
            {
                return Result.Fail(AuthorError.DoesntExist);
            }
            else if (application.Status != ApplicationStatus.Pending)
            {
                return Result.Fail(ApplicationError.NoUnsubmitted);
            }
            else
            {
                return new ApplicationDto()
                {
                    Id = application.Id,
                    AuthorId = application.AuthorId,
                    ActvityTypeName = application.Activity.Type,
                    Name = application.Name,
                    Description = application.Description,
                    Outline = application.Outline,
                };
            }
        }

        public async Task<Result<ApplicationDto>> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication, CancellationToken cancellationToken)
        {
            var validationResult = await _validatorUpdate.ValidateAsync(updatedApplication, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(failure => failure.ErrorMessage));
            }

            var application = await _applicationRepository.GetApplicationByApplicationIdAsync(applicationId, cancellationToken);

            if (application == null)
            {
                return Result.Fail(ApplicationError.DoesntExist);
            }

            if (application.Status == ApplicationStatus.Active)
            {
                return Result.Fail(ApplicationError.CantUpdateActive);
            }
           
            application.Name = updatedApplication.Name ?? application.Name;
            application.Description = updatedApplication.Description ?? application.Description;
            application.Outline = updatedApplication.Outline ?? application.Outline;
            application.ActivityType = updatedApplication.ActvityTypeName;

            await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);

            return new ApplicationDto
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.Type,
                Name = application.Name,
                Description = application.Description,
                Outline = application.Outline,
            };
        }

        public async Task<Result> SubmitApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetApplicationByApplicationIdAsync(applicationId, cancellationToken);

            if (application == null)
            {
                return Result.Fail(ApplicationError.DoesntExist);
            }

            if ( application.Status is ApplicationStatus.Active )
            {
                return Result.Fail(ApplicationError.CantUpdateActive);
            }
            
            application.Status = ApplicationStatus.Active;
            application.SubmitDate = DateTime.UtcNow;

            await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> DeleteAplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetApplicationByApplicationIdAsync(applicationId, cancellationToken);

            if (application == null)
            {
                return Result.Fail(ApplicationError.DoesntExist);
            }

            if (application.Status == ApplicationStatus.Active)
            {
                return Result.Fail(ApplicationError.CantDeleteActive);
            }
            
            await _applicationRepository.DeleteApplicationAsync(application, cancellationToken);

            return Result.Ok();
        }
    }
}
