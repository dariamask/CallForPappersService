using CallForPappersService.Data.Dto;

namespace CallForPappersService.Services
{
    public interface IActivityService
    {
        public Task<List<ActivityDto>> GetActivitiesAsync();
    }
}
