using CallForPappersService.Data;
using CallForPappersService.Interfaces;
using CallForPappersService.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;
        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public bool ApplicationExists(Guid appId)
        {
            throw new NotImplementedException();
        }

        public bool CreateApplication(ApplicationModel application)
        {
            _context.Add(application);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool DeleteApplication(ApplicationModel application)
        {
            throw new NotImplementedException();
        }

        public ApplicationModel GetApplication(Guid authorGuid)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApplicationModel> GetApplicationsByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public ApplicationModel GetCurrentApplication(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public bool SubmitApplicationForReview(ApplicationModel application)
        {
            throw new NotImplementedException();
        }

        public bool UpdateApplication(Guid authorId, ApplicationModel application)
        {
            throw new NotImplementedException();
        }
    }
}
