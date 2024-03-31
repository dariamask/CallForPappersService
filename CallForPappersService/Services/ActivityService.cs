using CallForPappersService.Data.Dto;
using CallForPappersService.Repository;

namespace CallForPappersService.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<ActivityDto>> GetActivitiesAsync()
        {
            var activities = await _activityRepository.GetActivitiesAsync();

            var dtos = new List<ActivityDto>();

            foreach (var activity in activities)
            {
                var dto = new ActivityDto()
                {
                    Id = activity.Id,
                    ActivityType = activity.ActivityType,
                    Description = activity.Description,
                };

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
