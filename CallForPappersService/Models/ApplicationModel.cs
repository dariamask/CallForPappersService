using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallForPappersService.Models
{
    public class ApplicationModel
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }
        [JsonPropertyName("name")][Required][StringLength(100)]public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("outline")][Required]public string Outline { get; set; }
        [JsonPropertyName("author")] public Guid AuthorId { get; set; }
        [JsonPropertyName("activity")] public string Activity { get; set; }
    }

    public enum Status
    {
        Pending = 1,
        Active,
    }
}
