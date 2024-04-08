using CallForPappersService_BAL.Dto;
using CallForPappersService_BAL.Validations.Result;
using System;

namespace CallForPappersService_BAL.Services
{
    public interface IApplicationService
    {
        public Task<Result<ApplicationDto>> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
        public Task<Result<ApplicationDto>> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<List<ApplicationDto>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken);
        public Task<List<ApplicationDto>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken);
        public Task<ApplicationDto> GetUnsubmittedApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<Result<ApplicationDto>> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication, CancellationToken cancellationToken);
        public Task<Result> SubmitApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<Result> DeleteAplicationAsync(Guid applicationId, CancellationToken cancellationToken);
    }
}
