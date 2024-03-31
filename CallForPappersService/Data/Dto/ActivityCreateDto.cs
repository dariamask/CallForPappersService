using CallForPappersService.Data.Entities;
using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Dto
{
    public class ActivityCreateDto
    {
        [JsonPropertyName("activity")]
        public ActivityType ActivityType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
