using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using CallForPappersService.Validations.Result;

namespace CallForPappersService.Repository
{
    public interface IApplicationRepository
    {
        Task<Result<Application>> GetApplicationAsync(Guid applicationId);
        Task<bool> DraftApplicationExistsAsync(Guid authorId);
        Task<bool> ApplicationExistsAsync(Guid applicationId);
        Task<bool> CreateApplicationAsync(Application application);
        Task<bool> UpdateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(Application application);
        Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder);
        Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter);
        Task<Application> GetUnsubmittedApplicationAsync(Guid applicationId);
    }
}
