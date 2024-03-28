namespace CallForPappersService.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public string Description { get; set; }
        ICollection<ApplicationModel> Applications { get; set; }
    }
}
