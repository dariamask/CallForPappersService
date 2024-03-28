namespace CallForPappersService.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
