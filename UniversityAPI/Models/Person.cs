namespace UniversityAPI.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}
