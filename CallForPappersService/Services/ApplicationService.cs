using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using CallForPappersService.Repository;

namespace CallForPappersService.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(IApplicationRepository applicationRepository, IActivityRepository activityRepository, ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _activityRepository = activityRepository;
            _logger = logger;
        }
       
        public async Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(dto);

            //if (_applicationRepository.DraftApplicationExistsAsync(dto.AuthorId))

            // проверить createDto

            var application = new Application
            {
                AuthorId = dto.AuthorId,
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

        public async Task<ApplicationDto> GetApplicationAsync(Guid applicationId)
        {
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

        public async Task<List<ApplicationDto>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder)
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

        public async Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter)
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

        public async Task<ApplicationDto> GetUnsubmittedApplicationAsync(Guid applicationId)
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

        public async Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationDto updatedApplication)
        {
            if (applicationId == null || updatedApplication == null)
            {
                return null;
            }

            var currentApplication = await _applicationRepository.GetApplicationAsync(applicationId);

            currentApplication.Name = updatedApplication.Name!;
            currentApplication.Description = updatedApplication.Description!;
            currentApplication.Outline = updatedApplication.Outline!;
            currentApplication.ActivityId = _activityRepository.GetActivityId(updatedApplication.ActvityTypeName);

            await _applicationRepository.UpdateApplicationAsync(currentApplication);

            return new ApplicationDto
            {
                Id = currentApplication.Id,
                AuthorId = currentApplication.AuthorId,
                ActvityTypeName = currentApplication.Activity.ActivityType,
                Name = currentApplication.Name!,
                Description = currentApplication.Description!,
                Outline = currentApplication.Outline!,
            };
        }

        public async Task SubmitApplicationAsync(Guid applicationId)
        {
            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            application.Status = ApplicationStatus.Active;

            await _applicationRepository.UpdateApplicationAsync(application);
        }

        public async Task DeleteAplicationAsync(Guid applicationId)
        {
            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            await _applicationRepository.DeleteApplicationAsync(application);
        }
    }
}
