﻿
using CallForPappersService_DAL.Data.Entities;
using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Dto
{
    public class ApplicationUpdateDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("outline")]
        public string? Outline { get; set; }

        [JsonPropertyName("activity")]
        public ActivityType ActvityTypeName { get; set; }
    }
}