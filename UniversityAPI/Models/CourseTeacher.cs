namespace UniversityAPI.Models
{
    // Junction table: many Teachers <-> many Courses
    public class CourseTeacher
    {
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}