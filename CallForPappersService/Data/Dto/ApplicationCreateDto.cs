using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Dto
{
    public record ApplicationCreateDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("outline")]
        public string? Outline { get; set; }

        [JsonPropertyName("type")]
        public string? ActvityTypeName { get; set; }

        [JsonPropertyName("author")]
        public Guid AuthorId { get; set; }
    }
}
