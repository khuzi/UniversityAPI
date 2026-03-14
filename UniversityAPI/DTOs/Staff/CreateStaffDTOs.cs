using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOs.Staff
{
    public class CreateStaffDTOs
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(18, 70)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be M or F")]
        public char Gender { get; set; }

        [Required]
        [Range(0, 1000000)]
        public double Salary { get; set; }
    }
}
