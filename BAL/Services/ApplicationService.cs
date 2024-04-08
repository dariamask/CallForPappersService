
using CallForPappersService_DAL.Data.Entities;
using CallForPappersService_DAL.Repository;
using CallForPappersService_BAL.Validations.Result;
using CallForPappersService_BAL.Dto;

namespace CallForPappersService_BAL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IAuthorRepository _authorRepository;

        public ApplicationService(IApplicationRepository applicationRepository, 
            IActivityRepository activityRepository, 
            IAuthorRepository authorRepository)
        {
            _applicationRepository = applicationRepository;
            _activityRepository = activityRepository;
            _authorRepository = authorRepository;
        }
       
        public async Task<Result<ApplicationDto>> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            if (await _applicationRepository.PendingApplicationExistsAsync(dto.AuthorId))
            {
                return ApplicationError.PendingAlreadyExist;
            }

            var application = new Application
            {
                AuthorId = dto.AuthorId!,
                Name = dto.Name!,
                Description = dto.Description!,
                Outline = dto.Outline!,
                CreatedDate = DateTime.Now,
                SubmitDate = null,
                Status = ApplicationStatus.Pending,
                ActivityId = _activityRepository.GetActivityId(dto.ActvityTypeName),             
            };
            
            await _applicationRepository.CreateApplicationAsync(application);

            return new ApplicationDto()
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType,              
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }

        public async Task<Result<ApplicationDto>> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId))
            {
                return ApplicationError.DoesntExist;
            }

            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            return new ApplicationDto()
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType,
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }

        public async Task<List<ApplicationDto>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken)
        {
            var applications = await _applicationRepository.GetUnsubmittedApplicationOlderDateAsync(unsubmittedOlder);

            return applications.Select(x => new ApplicationDto
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                ActvityTypeName = x.Activity.ActivityType,
                Name = x.Name!,
                Description = x.Description!,
                Outline = x.Outline!,
            }).ToList();
        }

        public async Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken)
        {
            var applications = await _applicationRepository.GetApplicationsSubmittedAfterDateAsync(submittedAfter);

            return applications.Select(x => new ApplicationDto
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                ActvityTypeName = x.Activity.ActivityType,
                Name = x.Name!,
                Description = x.Description!,
                Outline = x.Outline!,
            }).ToList();
        }

        public async Task<ApplicationDto> GetUnsubmittedApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetUnsubmittedApplicationAsync(applicationId);

            if (application == null)
            {
                return null;
            }
            else
            {
                return new ApplicationDto()
                {
                    Id = application.Id,
                    AuthorId = application.AuthorId,
                    ActvityTypeName = application.Activity.ActivityType,
                    Name = application.Name!,
                    Description = application.Description!,
                    Outline = application.Outline!,
                };
            }
        }

        public async Task<Result<ApplicationDto>> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication, CancellationToken cancellationToken)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId))
            {
                return ApplicationError.DoesntExist;
            }

            var application = await _applicationRepository.GetApplicationAsync(applicationId);
  
            if (application.Status == ApplicationStatus.Active)
            {
                return ApplicationError.CantUpdateActive;
            }

            //не симпатично, надо переделать
            application.Name = updatedApplication.Name!;
            application.Description = updatedApplication.Description!;
            application.Outline = updatedApplication.Outline!;
            application.ActivityId = _activityRepository.GetActivityId(updatedApplication.ActvityTypeName);

            await _applicationRepository.UpdateApplicationAsync(application);

            return new ApplicationDto
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType,
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }

        public async Task<Result> SubmitApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId))
            {
                return ApplicationError.DoesntExist;
            }

            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            if ( application.Status is ApplicationStatus.Active )
            {
                return ApplicationError.CantUpdateActive;
            }
            
            application.Status = ApplicationStatus.Active;

            await _applicationRepository.UpdateApplicationAsync(application);

            return Result.Success();
        }

        public async Task<Result> DeleteAplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId))
            {
                return ApplicationError.DoesntExist;
            }

            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            if (application.Status == ApplicationStatus.Active)
            {
                return ApplicationError.CantDeleteActive;
            }
            
            await _applicationRepository.DeleteApplicationAsync(application);

            return Result.Success();
        }
    }
}
