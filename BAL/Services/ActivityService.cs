using CallForPappersService_BAL.Dto;
using CallForPappersService_DAL;
using CallForPappersService_DAL.Repository;
using FluentResults;

namespace CallForPappersService_BAL.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<Result<List<ActivityDto>>> GetActivitiesAsync()
        {
            var activities = await _activityRepository.GetActivitiesAsync();

            var activitiesDto = new List<ActivityDto>();

            return activitiesDto.Select(x => new ActivityDto
            {
                Id = x.Id,
                ActivityType = x.ActivityType,
                Description = x.Description,
            }).ToList();
        }
    }
}
