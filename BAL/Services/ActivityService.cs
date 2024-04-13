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

        public async Task<Result<List<ActivityDto>>> GetActivitiesAsync(CancellationToken cancellationToken)
        {
            var activities = await _activityRepository.GetActivitiesAsync(cancellationToken);

            return activities.Select(x => new ActivityDto
            {
                ActivityType = x.ActivityType,
                Description = x.Description!,
            }).ToList();
        }
    }
}
