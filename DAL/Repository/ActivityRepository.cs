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
    }
}
