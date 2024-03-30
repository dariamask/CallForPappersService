using CallForPappersService.Data.Entities;

namespace CallForPappersService.Repository
{
    public interface IActivityRepository
    {
        ICollection<Activity> Activities();
        Activity GetActivity(Guid activityId);
        Activity GetActivity(ActivityType activityTypeName);
    }
}
