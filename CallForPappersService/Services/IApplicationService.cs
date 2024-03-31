using CallForPappersService.Data.Dto;
using System;

namespace CallForPappersService.Services
{
    public interface IApplicationService
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
        public Task<ApplicationDto> GetApplicationAsync(Guid applicationId);
        public Task<List<ApplicationDto>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder);
        public Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter);
        public Task<ApplicationDto> GetUnsubmittedApplicationAsync(Guid applicationId);
        public Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationDto updatedApplication);
        public Task SubmitApplicationAsync(Guid applicationId);
        public Task DeleteAplicationAsync(Guid applicationId);
    }
}
