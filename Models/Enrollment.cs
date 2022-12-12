namespace CRMEducacional.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public virtual Lead? Lead { get; set; }
        public virtual Course? Course { get; set; }

    }
}
