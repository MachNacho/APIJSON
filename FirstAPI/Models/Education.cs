namespace FirstAPI.Models
{
    public class Education
    {
        public int ID { get; set; }
        public string? Degree { get; set; }
        public  string? Institution { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Grade { get; set; }
        public string[]? Description { get; set; }
        public string? ImageSrc { get; set; }
    }
}
