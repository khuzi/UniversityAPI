using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOs.Teacher
{
    public class CreateStudentDTOs
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(16, 60)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be M or F")]
        public char Gender { get; set; }
    }
}
