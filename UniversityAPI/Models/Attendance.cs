namespace UniversityAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int DaysPresent { get; set; }

        // Foreign Keys
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Enrollment Enrollment { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}