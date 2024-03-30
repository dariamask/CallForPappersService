using CallForPappersService.Data.Entities;

namespace CallForPappersService.Repository
{
    public interface IActivityRepository
    {
        ICollection<Activity> Activities();
        Activity GetActivity(int activityId);

    }
}
