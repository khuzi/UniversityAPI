using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOs.Marks
{
    public class CreateMarkDTOs
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Range(0, 30)]
        public int Mid { get; set; }
        [Range(0, 40)]
        public int Final { get; set; }
        [Range(0, 10)]
        public int Assignment { get; set; }
        [Range(0, 10)]
        public int Quiz { get; set; }
        [Range(0, 10)]
        public int Project { get; set; }
    }
}
