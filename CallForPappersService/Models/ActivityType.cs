namespace CallForPappersService.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
