namespace UniversityAPI.Models
{
    public class Teacher : Person
    {
        // Navigation
        public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
    }
}
