using CallForPappersService_DAL.Data;
using CallForPappersService_DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService_DAL.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;
        public ActivityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Activity>> GetActivitiesAsync(CancellationToken cancellationToken)
        {
            return await _context.Activities.ToListAsync(cancellationToken);
        }

        public async Task<Activity> GetActivityAsync(ActivityType activityType, CancellationToken cancellationToken)
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.ActivityType == activityType, cancellationToken);
        }

        public async Task<Activity> GetActivityAsync(Guid activityId, CancellationToken cancellationToken)
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.Id == activityId, cancellationToken);
        }

        public async Task<Guid> GetActivityIdAsync(ActivityType activityType, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.Where(a => a.ActivityType == activityType).FirstOrDefaultAsync(cancellationToken);
            return activity.Id;
        }
    }
}
