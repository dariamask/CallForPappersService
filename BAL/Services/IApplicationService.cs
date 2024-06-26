﻿using CallForPappersService_BAL.Dto;
using FluentResults;


namespace CallForPappersService_BAL.Services
{
    public interface IApplicationService
    {
        public Task<Result<ApplicationDto>> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
        public Task<Result<ApplicationDto>> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<Result<List<ApplicationDto>>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken);
        public Task<Result<List<ApplicationDto>>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken);
        public Task<Result<ApplicationDto>> GetUnsubmittedApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<Result<ApplicationDto>> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateDto updatedApplication, CancellationToken cancellationToken);
        public Task<Result> SubmitApplicationAsync(Guid applicationId, CancellationToken cancellationToken);
        public Task<Result> DeleteAplicationAsync(Guid applicationId, CancellationToken cancellationToken);
    }
}
