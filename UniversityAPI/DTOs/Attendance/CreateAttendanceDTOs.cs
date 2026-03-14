using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOs.Attendance
{
    public class CreateAttendanceDTOs
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}
