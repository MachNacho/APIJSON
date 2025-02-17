using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class ProjectTags
    {
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Projects { get; set; }
        [ForeignKey("Tags")]
        public int TagID { get; set; }
        public Tags Tags { get; set; }
    }
}
