using CallForPappersService_DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService_DAL.Repository
{
    public interface IActivityRepository
    {
        Task<ICollection<Activity>> GetActivitiesAsync(CancellationToken cancellationToken);
        Task<Activity?> GetActivityAsync(ActivityType activityType, CancellationToken cancellationToken);
    }
}
