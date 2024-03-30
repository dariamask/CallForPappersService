using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
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
            return _context.Applications.Any(a => a.Id == appId);
        }

        public void CreateApplication(Application application)
        {
            _context.Add(application);
            _context.SaveChanges();
        }

        public bool DraftApplicationExists(Guid authorId)
        {
            return _context.Applications.Any(a => a.AuthorId == authorId);
        }

        public void DeleteApplication(Application application)
        {
            _context.Remove(application);
            _context.SaveChanges();
        }

        public Application GetApplication(Guid applicationId)
        {
            var app = _context.Applications            
                .Where(a => a.Id == applicationId)
                .Include(a => a.Activity)
                .FirstOrDefault();

            return app;
        }

        public ICollection<Application> GetApplicationsByDate(DateTime dateTime)
        {
            return _context.Applications.Where(a => a.CreatedDate >= dateTime).ToList();
        }

        public Application GetDraftApplication(Guid authorId)
        {
            return _context.Applications.Where(a => a.AuthorId == authorId).FirstOrDefault();
        }

        public void UpdateApplication(Application application)
        {
            _context.Update(application);
            _context.SaveChanges();
        }

        public ICollection<Application> GetAll()
        {
            return _context.Applications.ToList();
        }

        public List<Application> GetUnsubmittedApplicationOlderDate(DateTime unsubmittedOlder)
        {
            return _context.Applications.Where(a => a.CreatedDate < unsubmittedOlder && a.Status == ApplicationStatus.Pending).ToList();
        }
    }
}
