using CallForPappersService.Data;
using CallForPappersService.Data.Entities;

using CallForPappersService.Models;
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

        public Activity GetActivity(int activityId)
        {
            return new Activity();
        }
    }
}
