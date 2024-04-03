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
            if (await _applicationRepository.DraftApplicationExistsAsync(dto.AuthorId)) return null;

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
            
            if (!await _applicationRepository.CreateApplicationAsync(application)) return null;

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

        public async Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication)
        {
            
            if (updatedApplication == null) return null;
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId)) return null;

            var currentApplication = await _applicationRepository.GetApplicationAsync(applicationId);

            if (currentApplication.Status == ApplicationStatus.Active) return null;

            currentApplication.Name = updatedApplication.Name!;
            currentApplication.Description = updatedApplication.Description!;
            currentApplication.Outline = updatedApplication.Outline!;
            currentApplication.ActivityId = _activityRepository.GetActivityId(updatedApplication.ActvityTypeName);

            if (!await _applicationRepository.UpdateApplicationAsync(currentApplication)) return null;

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

        public async Task<bool> SubmitApplicationAsync(Guid applicationId)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId)) return false;

            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            application.Status = ApplicationStatus.Active;

            return await _applicationRepository.UpdateApplicationAsync(application);
        }

        public async Task<bool> DeleteAplicationAsync(Guid applicationId)
        {
            if (!await _applicationRepository.ApplicationExistsAsync(applicationId)) return false;

            var application = await _applicationRepository.GetApplicationAsync(applicationId);

            if (application.Status == ApplicationStatus.Active) return false;

            return await _applicationRepository.DeleteApplicationAsync(application);
        }
    }
}
