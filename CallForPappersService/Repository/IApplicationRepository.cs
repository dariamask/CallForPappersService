using CallForPappersService.Data.Entities;

namespace CallForPappersService.Repository
{
    public interface IApplicationRepository
    {
        ICollection<Application> GetAll();
        Application GetApplication(Guid applicationId);
        Application GetDraftApplication(Guid authorId);
        ICollection<Application> GetApplicationsByDate(DateTime dateTime);
        bool ApplicationExists(Guid appId);
        bool DraftApplicationExists(Guid authorId);
        void CreateApplication(Application application);
        void UpdateApplication(Application application);
        void DeleteApplication(Application application);
        Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder);
        Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter);
    }
}
