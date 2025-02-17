using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public List<ProjectTags>? Tags { get; set; } = new List<ProjectTags>();
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);// Default value is currrent day
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
    }
}
