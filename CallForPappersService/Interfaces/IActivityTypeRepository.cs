using CallForPappersService.Models;

namespace CallForPappersService.Interfaces
{
    public interface IActivityTypeRepository
    {
        ICollection<ActivityTypeModel> Activities();
        Activity GetActivity (int activityId);

    }
}
