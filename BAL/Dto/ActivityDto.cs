using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Dto
{
    public class ActivityDto : ActivityCreateDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
