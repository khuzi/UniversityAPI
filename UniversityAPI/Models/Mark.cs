using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPI.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int Mid { get; set; }
        public int Final { get; set; }
        public int Assignment { get; set; }
        public int Quiz { get; set; }
        public int Project { get; set; }

        [NotMapped]
        public int Total => Mid + Final + Assignment + Quiz + Project; // computed, not stored

        // Foreign Keys
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Enrollment Enrollment { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}