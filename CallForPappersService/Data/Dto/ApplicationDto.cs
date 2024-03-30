using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Dto
{
    public record ApplicationDto : ApplicationCreateDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
