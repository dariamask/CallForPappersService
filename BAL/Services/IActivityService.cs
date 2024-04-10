

using CallForPappersService_BAL.Dto;
using FluentResults;

namespace CallForPappersService_BAL.Services
{
    public interface IActivityService
    {
        public Task<Result<List<ActivityDto>>> GetActivitiesAsync();
    }
}
