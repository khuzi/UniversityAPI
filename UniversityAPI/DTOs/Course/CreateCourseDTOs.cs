namespace UniversityAPI.DTOs.Course
{
    public class CreateCourseDTOs
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int CreditHour { get; set; }
    }
}
