using CallForPappersService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallForPappersService.Interfaces
{
    public interface IApplicationRepository
    {
        Application GetApplication(Guid authorGuid);
        Application GetCurrentApplication(string userId);
        ICollection<Application> GetApplicationsByDate(DateTime dateTime);
        bool ApplicationExists(int appId);
        bool CreateApplication(Application application);
        bool SubmitApplicationForReview(Application application);
        bool UpdateApplication(Guid authorId, Application application);
        bool DeleteApplication(Application pokemon);
    }
}
