using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_DAL.Repository
{
    public interface IActivityRepository
    {
        Task<ICollection<Activity>> GetActivitiesAsync(CancellationToken cancellationToken);
    }
}
