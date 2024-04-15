using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_BAL.Dto
{
    public class ActivityDto
    {
        public ActivityType ActivityType { get; set; }

        public string? Description { get; set; }
    }
}
