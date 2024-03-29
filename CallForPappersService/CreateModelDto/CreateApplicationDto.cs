﻿using System.Text.Json.Serialization;

namespace CallForPappersService.Dto
{
    public class CreateApplicationDto
    {        
        [JsonPropertyName("author")] public Guid Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("outline")] public string Outline { get; set; }
        [JsonPropertyName("type")] public string ActvityTypeName { get; set; }
        [JsonPropertyName("author")] public Guid AuthorId { get; set; }
        [JsonPropertyName("author")] public Status Status { get; set; }
    }
    public enum Status
    {
        Pending = 1,
        Active,
    }
}
