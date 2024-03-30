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

        public ICollection<Activity> Activities()
        {
            return _context.Activities.ToList();
        }

        public Activity GetActivity(Guid activityId)
        {
            return _context.Activities.Where(a => a.Id == activityId).FirstOrDefault();
        }

        public Activity GetActivity(ActivityType activityTypeName)
        {
            
            return _context.Activities.Where(a => a.ActivityType == activityTypeName).FirstOrDefault();
        }
    }
}
