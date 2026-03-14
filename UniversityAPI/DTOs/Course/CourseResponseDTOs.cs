using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOs.Course
{
    public class CourseResponseDTOs
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CourseName { get; set; }

        [Required]
        [Range(1,6)]
        public int CreditHour { get; set; }
    }
}
