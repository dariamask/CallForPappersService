using CallForPappersService.Models;

namespace CallForPappersService.Interfaces
{
    public interface IActivityTypeRepository
    {
        ICollection<ActivityType> Activities();

    }
}
