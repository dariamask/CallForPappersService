using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Dto
{
    public class ActivityCreateDto
    {
        [JsonPropertyName("activity")]
        public string? ActivityType { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
