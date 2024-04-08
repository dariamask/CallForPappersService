using CallForPappersService_DAL.Data.Entities;


namespace CallForPappersService_DAL.Repository
{
    public interface IApplicationRepository
    {
        Task<Application> GetApplicationAsync(Guid applicationId);
        Task<bool> PendingApplicationExistsAsync(Guid authorId);
        Task<bool> ApplicationExistsAsync(Guid applicationId);
        Task<bool> CreateApplicationAsync(Application application);
        Task<bool> UpdateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(Application application);
        Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder);
        Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter);
        Task<Application> GetUnsubmittedApplicationAsync(Guid applicationId);
    }
}
