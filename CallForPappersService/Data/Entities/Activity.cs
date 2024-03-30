using System.Text.Json.Serialization;

namespace CallForPappersService.Data.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public ActivityType ActivityType { get; set; }
         public string Description { get; set; }
    }

    public enum ActivityType
    { 
        Report = 0,
        MasterClass = 1,
        Discussion = 2,
    }
}
