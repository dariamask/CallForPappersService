using CallForPappersService.Interfaces;
using CallForPappersService.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DbContext _context;
        public ApplicationRepository(DbContext context)
        {
            _context = context;
        }
        public bool ApplicationExists(int appId)
        {
            throw new NotImplementedException();
        }

        public bool CreateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApplication(Application pokemon)
        {
            throw new NotImplementedException();
        }

        public Application GetApplication(Guid authorGuid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Application> GetApplicationsByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Application GetCurrentApplication(string userId)
        {
            throw new NotImplementedException();
        }

        public bool SubmitApplicationForReview(Application application)
        {
            throw new NotImplementedException();
        }

        public bool UpdateApplication(Guid authorId, Application application)
        {
            throw new NotImplementedException();
        }
    }
}
