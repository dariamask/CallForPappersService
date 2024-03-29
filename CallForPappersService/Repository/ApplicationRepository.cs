using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
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
            return _context.Applications.Any(a => a.Id == appId);
        }

        public void CreateApplication(Application application)
        {
            _context.Add(application);
            _context.SaveChanges();
        }

        public bool DraftApplicationExists(Guid authorId)
        {
            return _context.Applications.Any(a => a.AuthorId == authorId && a.Status == "Unsubmitted");
        }

        public void DeleteApplication(Application application)
        {
            _context.Remove(application);
            _context.SaveChanges();
        }

        public Application GetApplication(Guid authorGuid)
        {
            return _context.Applications.Where(a => a.Id == authorGuid).FirstOrDefault();

        }

        public ICollection<Application> GetApplicationsByDate(DateTime dateTime)
        {
            return _context.Applications.Where(a => a.CreatedDate >= dateTime).ToList();
        }

        public Application GetDraftApplication(Guid authorId)
        {
            return _context.Applications.Where(a => a.AuthorId == authorId && a.Status == "Unsubmitted").FirstOrDefault();
        }

        public void UpdateApplication(Application application)
        {
            _context.Update(application);
            _context.SaveChanges();
        }
    }
}
