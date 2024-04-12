﻿using System.ComponentModel.DataAnnotations;

namespace CallForPappersService_DAL.Data.Entities
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Outline { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }

    public enum ApplicationStatus
    {
        Pending = 0,
        Active = 1,
    }
}