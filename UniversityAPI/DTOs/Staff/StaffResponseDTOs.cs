namespace UniversityAPI.DTOs.Staff
{
    public class StaffResponseDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public char Gender { get; set; }
        public double Salary { get; set; }
    }
}
