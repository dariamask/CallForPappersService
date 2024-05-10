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
        Report = 1,
        MasterClass = 2,
        Discussion = 3,
    }
}
