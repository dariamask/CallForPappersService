﻿using CallForPappersService_DAL.Data.Entities;
using System.Text.Json.Serialization;

namespace CallForPappersService_BAL.Dto
{
    public record ApplicationDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Outline { get; set; }

        public ActivityType ActvityTypeName { get; set; }

        public Guid AuthorId { get; set; }
    }
}
