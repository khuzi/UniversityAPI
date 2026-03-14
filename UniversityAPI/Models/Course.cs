namespace UniversityAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int CreditHour { get; set; }

        // Navigation
        public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}