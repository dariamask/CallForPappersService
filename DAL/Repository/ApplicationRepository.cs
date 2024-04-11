using CallForPappersService_DAL.Data;
using CallForPappersService_DAL.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace CallForPappersService_DAL.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;
        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Application> GetApplicationAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .Where(a => a.Id == applicationId)
                .Include(a => a.Activity)
                .FirstOrDefaultAsync(cancellationToken);

        }

        public async Task CreateApplicationAsync(Application application, CancellationToken cancellationToken)
        {
            _context.Add(application);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ApplicationExistsAsync(Guid applicationId, CancellationToken cancellationToken)
        {
            return await _context.Applications.AnyAsync(a => a.Id == applicationId, cancellationToken);
        }

        public async Task<bool> PendingApplicationExistsAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _context.Applications.AnyAsync(a => a.AuthorId == authorId && a.Status == ApplicationStatus.Pending, cancellationToken);
        }

        public async Task DeleteApplicationAsync(Application application, CancellationToken cancellationToken)
        {
            _context.Remove(application);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateApplicationAsync(Application application, CancellationToken cancellationToken)
        {
            _context.Update(application);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Application>> GetUnsubmittedApplicationOlderDateAsync(DateTime? unsubmittedOlder, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .Where(a => a.CreatedDate > unsubmittedOlder && a.Status == ApplicationStatus.Pending)
                .Include(a => a.Activity)          
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Application>> GetApplicationsSubmittedAfterDateAsync(DateTime? submittedAfter, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .Where(a => a.SubmitDate < submittedAfter && a.Status == ApplicationStatus.Active)
                .Include(a => a.Activity)
                .ToListAsync(cancellationToken);
        }

        public async Task<Application> GetUnsubmittedApplicationAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .Where(a => a.AuthorId == authorId && a.Status == ApplicationStatus.Pending)
                .Include (a => a.Activity)
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<bool> AuthorExistsAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _context.Applications.AnyAsync(a => a.AuthorId == authorId, cancellationToken);
        }
    }
}
