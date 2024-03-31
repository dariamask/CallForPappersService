using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Dto
{
    public class ActivityDto : ActivityCreateDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
