namespace UniversityAPI.DTOs.Student
{
    public class StudentResponseDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
