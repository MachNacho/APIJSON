namespace FirstAPI.Models
{
    public class Achivement
    {
        public string? Name { get; set; }
        public DateOnly DateAquired { get; set; } = DateOnly.FromDateTime(DateTime.Now);// Default value is currrent day
        public string? Location { get; set; }
    }
}
