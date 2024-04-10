using CallForPappersService_DAL.Data.Entities;
using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Dto
{
    public class ActivityDto
    {
        public Guid Id { get; set; }

        public ActivityType ActivityType { get; set; }

        public string Description { get; set; }
    }
}
