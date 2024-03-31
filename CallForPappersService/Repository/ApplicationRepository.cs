using CallForPappersService.Data;
using CallForPappersService.Data.Dto;
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

        public async Task<bool> ApplicationExists(Guid appId)
        {
            return await _context.Applications.AnyAsync(a => a.Id == appId);
        }

        public async Task CreateApplicationAsync(Application application)
        {
            _context.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DraftApplicationExistsAsync(Guid authorId)
        {
            return await _context.Applications.AnyAsync(a => a.AuthorId == authorId && a.Status == ApplicationStatus.Pending);
        }

        public async Task DeleteApplicationAsync(Application application)
        {
            _context.Remove(application);
            await _context.SaveChangesAsync();
        }

        public async Task<Application> GetApplicationAsync(Guid applicationId)
        {
            return await _context.Applications
                .Where(a => a.Id == applicationId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateApplicationAsync(Application application)
        {
            _context.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder)
        {
            return await _context.Applications
                .Where(a => a.CreatedDate > unsubmittedOlder && a.Status == ApplicationStatus.Pending)
                .Include(a => a.Activity)
                .ToListAsync();
        }

        public async Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter)
        {
            return await _context.Applications
                .Where(a => a.CreatedDate > submittedAfter && a.Status == ApplicationStatus.Active)
                .Include(a => a.Activity)
                .ToListAsync();
        }

        public async Task<Application> GetUnsubmittedApplicationAsync(Guid applicationId)
        {
            var app = await _context.Applications
                .Where(a => a.Id == applicationId && a.Status == ApplicationStatus.Pending)
                .Include(a => a.Activity)
                .FirstOrDefaultAsync();

            return app;
        }
    }
}
