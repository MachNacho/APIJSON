namespace FirstAPI.Models
{
    public class Education
    {
        public string? Degree { get; set; }
        public  string? Institution { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Grade { get; set; }
        public string[]? Description { get; set; }
        public string? ImageSrc { get; set; }
    }
}
