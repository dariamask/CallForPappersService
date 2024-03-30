using CallForPappersService.Data.Entities;
using CallForPappersService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallForPappersService.Interfaces
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
    }
}
