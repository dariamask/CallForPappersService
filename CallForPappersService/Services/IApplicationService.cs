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
        public Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication);
        public Task<bool> SubmitApplicationAsync(Guid applicationId);
        public Task<bool> DeleteAplicationAsync(Guid applicationId);
    }
}
