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
            return _context.Activities.ToList();
        }

        public Activity GetActivity(ActivityType activityType)
        {
            return _context.Activities.Where(a => a.ActivityType == activityType).FirstOrDefault();
        }
    }
}
