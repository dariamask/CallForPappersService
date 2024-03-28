using CallForPappersService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallForPappersService.Interfaces
{
    public interface IApplicationRepository
    {
        ApplicationModel GetApplication(Guid authorGuid);
        ApplicationModel GetCurrentApplication(Guid authorId);
        ICollection<ApplicationModel> GetApplicationsByDate(DateTime dateTime);
        bool ApplicationExists(Guid appId);
        bool CreateApplication(ApplicationModel application);
        bool SubmitApplicationForReview(ApplicationModel application);
        bool UpdateApplication(Guid authorId, ApplicationModel application);
        bool DeleteApplication(ApplicationModel application);
    }
}
