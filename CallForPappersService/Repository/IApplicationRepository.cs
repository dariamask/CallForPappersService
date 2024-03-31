using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;

namespace CallForPappersService.Repository
{
    public interface IApplicationRepository
    {
        Task<Application> GetApplicationAsync(Guid applicationId);
        Task<bool> DraftApplicationExistsAsync(Guid authorId);
        Task CreateApplicationAsync(Application application);
        Task UpdateApplicationAsync(Application application);
        Task DeleteApplicationAsync(Application application);
        Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder);
        Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter);
        Task<Application> GetUnsubmittedApplicationAsync(Guid applicationId);
    }
}
