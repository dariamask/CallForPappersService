using CallForPappersService.Data.Entities;
using CallForPappersService.Models;

namespace CallForPappersService.Interfaces
{
    public interface IActivityRepository
    {
        ICollection<Activity> Activities();
        Activity GetActivity (int activityId);

    }
}
