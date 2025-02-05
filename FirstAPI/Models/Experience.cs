namespace FirstAPI.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public string? Role { get; set; }
        public string? Organisation { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string[]? Experiences { get; set; }
        public string? ImageSrc { get; set; }
    }
}
