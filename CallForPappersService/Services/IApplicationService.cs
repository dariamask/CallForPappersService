using CallForPappersService.Data.Dto;
using CallForPappersService.Validations.Result;
using System;

namespace CallForPappersService.Services
{
    public interface IApplicationService
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
        Task<Result<ApplicationDto>> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<List<ApplicationDto>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken);
        public Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken);
        public Task<ApplicationDto> GetUnsubmittedApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication, CancellationToken cancellationToken);
        public Task<bool> SubmitApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<bool> DeleteAplicationAsync(Guid applicationId, CancellationToken cancellationToken);
    }
}
