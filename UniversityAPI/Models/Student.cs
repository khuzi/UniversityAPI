namespace UniversityAPI.Models
{
    public class Student : Person
    {
        public string Department { get; set; } = string.Empty;

        // Navigation
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Mark> Marks { get; set; } = new List<Mark>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
