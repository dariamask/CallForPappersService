using CallForPappersService.Data;
using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using CallForPappersService.Validations.Result;
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

        public async Task<Application> GetApplicationAsync(Guid applicationId)
        {
            var app = await _context.Applications
                .Where(a => a.Id == applicationId)
                .Include(a => a.Activity)
                .FirstOrDefaultAsync();

            return app;
        }


        public async Task<bool> CreateApplicationAsync(Application application)
        {
            _context.Add(application);
            return await Save();
        }

        public async Task<bool> ApplicationExistsAsync(Guid applicationId)
        {
            return await _context.Applications.AnyAsync(a => a.Id == applicationId);
        }

        public async Task<bool> PendingApplicationExistsAsync(Guid authorId)
        {
            return await _context.Applications.AnyAsync(a => a.AuthorId == authorId && a.Status == ApplicationStatus.Pending);
        }

        //работает не так, как я ожидала. 
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DeleteApplicationAsync(Application application)
        {
            _context.Remove(application);
            return await Save();
        }

        public async Task<bool> UpdateApplicationAsync(Application application)
        {
            _context.Update(application);
            return await Save();
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
                .Where(a => a.SubmitDate < submittedAfter && a.Status == ApplicationStatus.Active)
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
