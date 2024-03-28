using CallForPappersService.Interfaces;
using CallForPappersService.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly DbContext _context;
        public ActivityTypeRepository (DbContext context)
        {
            _context = context;
        }
        public ICollection<ActivityType> Activities()
        {
            throw new NotImplementedException();
        }
    }
}
