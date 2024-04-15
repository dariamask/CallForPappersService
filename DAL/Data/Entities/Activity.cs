using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallForPappersService_DAL.Data.Entities
{
    public class Activity
    {
        public ActivityType Type { get; set; }
        public string Description { get; set; } = null!;
        public List<Application> Applications { get; set; } //= [];
    }

    public enum ActivityType
    { 
        Report = 0,
        MasterClass = 1,
        Discussion = 2,
    }
}
