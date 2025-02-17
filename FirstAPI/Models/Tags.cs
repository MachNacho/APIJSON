using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Tags
    {
        [Key]
        public int ID { get; set; }
        public string TAG { get; set; }
        public List<ProjectTags> Projects { get; set; } = new List<ProjectTags>();
    }
}
