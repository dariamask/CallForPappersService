﻿using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_DAL.Repository
{
    public interface IApplicationRepository
    {
        Task<Application?> GetApplicationByApplicationIdAsync(Guid applicationId, CancellationToken cancellationToken);
        Task<Application?> GetApplicationByAuthorIdAsync(Guid applicationId, CancellationToken cancellationToken);
        Task<bool> PendingApplicationExistsAsync(Guid authorId, CancellationToken cancellationToken);
        Task<bool> ApplicationExistsAsync(Guid applicationId, CancellationToken cancellationToken);
        Task CreateApplicationAsync(Application application, CancellationToken cancellationToken);
        Task UpdateApplicationAsync(Application application, CancellationToken cancellationToken);
        Task DeleteApplicationAsync(Application application, CancellationToken cancellationToken);
        Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken);
        Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken);
    }
}
