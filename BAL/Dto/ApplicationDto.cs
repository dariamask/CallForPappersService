using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Dto
{
    public record ApplicationDto : ApplicationCreateDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
