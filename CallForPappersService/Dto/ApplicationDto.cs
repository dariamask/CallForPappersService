﻿namespace CallForPappersService.Dto
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Outline { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
