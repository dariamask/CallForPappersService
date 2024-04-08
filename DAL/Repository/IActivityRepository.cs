using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_DAL.Repository
{
    public interface IActivityRepository
    {
        Task<ICollection<Activity>> GetActivitiesAsync();
        Activity GetActivity(ActivityType activityType);
        Guid GetActivityId(ActivityType activityType);
    }
}
