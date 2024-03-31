using CallForPappersService.Data.Entities;

namespace CallForPappersService.Repository
{
    public interface IActivityRepository
    {
        Task<ICollection<Activity>> GetActivitiesAsync();
        Activity GetActivity(ActivityType activityType);
    }
}
