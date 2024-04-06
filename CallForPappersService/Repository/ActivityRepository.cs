using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;
        public ActivityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Activity>> GetActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public Activity GetActivity(ActivityType activityType)
        {
            return _context.Activities.Where(a => a.ActivityType == activityType).FirstOrDefault();
        }
        public Activity? GetActivity(Guid activityId)
        {
            return _context.Activities.Where(a => a.Id == activityId).FirstOrDefault();
        }

        public Guid GetActivityId(ActivityType activityType)
        {
            return _context.Activities.Where(a => a.ActivityType == activityType).FirstOrDefault().Id;
        }
    }
}
