using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using CallForPappersService.Interfaces;
using CallForPappersService.Repository;

namespace CallForPappersService.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(IApplicationRepository applicationRepository, ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
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
                Status = ApplicationStatus.Pending
            };

            return new ApplicationDto()
            {
                Id = new Guid(),
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType.ToString(),
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }
    }
}
