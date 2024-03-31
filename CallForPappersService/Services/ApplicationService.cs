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

            // проверить createDto

            var application = new Application
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name!,
                Description = dto.Description!,
                Outline = dto.Outline!,
                CreatedDate = DateTime.Now,
                Status = ApplicationStatus.Pending,
                ActivityId = _activityRepository.GetActivityId(dto.ActvityTypeName),             
            };

            _applicationRepository.CreateApplication(application);

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
            var application = _applicationRepository.GetApplication(applicationId);

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

            var dtos = new List<ApplicationDto>();

            foreach (var app in applications)
            {
                var dto = new ApplicationDto()
                {
                    Id = app.Id,
                    AuthorId = app.AuthorId,
                    ActvityTypeName = app.Activity.ActivityType,
                    Name = app.Name!,
                    Description = app.Description!,
                    Outline = app.Outline!,
                };
                dtos.Add(dto);
            }

            return dtos;

        }

        public async Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter)
        {
            var applications = await _applicationRepository.GetApplicationsSubmittedAfterDateAsync(submittedAfter);

            var dtos = new List<ApplicationDto>();

            foreach (var app in applications)
            {
                var dto = new ApplicationDto()
                {
                    Id = app.Id,
                    AuthorId = app.AuthorId,
                    ActvityTypeName = app.Activity.ActivityType,
                    Name = app.Name!,
                    Description = app.Description!,
                    Outline = app.Outline!,
                };
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<ApplicationDto> GetUnsubmittedApplication(Guid applicationId)
        {
            var application = _applicationRepository.GetUnsubmittedApplication(applicationId);

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

        public async Task<ApplicationDto> UpdateApplication(Guid applicationId, ApplicationDto updatedApplication)
        {
            if (applicationId == null || updatedApplication == null)
            {
                return null;
            }

            var currentApplication = _applicationRepository.GetApplication(applicationId);

            currentApplication.Name = updatedApplication.Name!;
            currentApplication.Description = updatedApplication.Description!;
            currentApplication.Outline = updatedApplication.Outline!;
            currentApplication.ActivityId = _activityRepository.GetActivityId(updatedApplication.ActvityTypeName);
            

           _applicationRepository.UpdateApplication(currentApplication);

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

        public async Task SubmitApplication(Guid applicationId)
        {
            var application = _applicationRepository.GetApplication(applicationId);

            application.Status = ApplicationStatus.Active;

            _applicationRepository.UpdateApplication(application);
        }

        public async Task DeleteAplication(Guid applicationId)
        {
            var application = _applicationRepository.GetApplication(applicationId);

            _applicationRepository.DeleteApplication(application);
        }
    }
}
