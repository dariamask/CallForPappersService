using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        [JsonPropertyName("activityType")] public string ActivityType { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
