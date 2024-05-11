namespace CallForPappersService_BAL.Dto
{
    public class ApplicationSubmitDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Outline { get; set; } = null!;
    }
}
