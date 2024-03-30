using CallForPappersService.Data.Dto;
using System;

namespace CallForPappersService.Services
{
    public interface IApplicationService
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
        public Task<ApplicationDto> GetApplicationAsync(Guid applicationId);
        public Task<List<ApplicationDto>> GetUsubmittedApplicationOlderDateAsync(DateTime unsubmittedOlder);
    }
}
