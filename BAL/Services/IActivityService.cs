

using CallForPappersService_BAL.Dto;

namespace CallForPappersService_BAL.Services
{
    public interface IActivityService
    {
        public Task<List<ActivityDto>> GetActivitiesAsync();
    }
}
