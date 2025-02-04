namespace FirstAPI.Models
{
    public class Project
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string[]? Tags { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);// Default value is currrent day
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
    }
}
