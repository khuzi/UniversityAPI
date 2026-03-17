using UniversityAPI.DTOs.Student;
using UniversityAPI.Models;
using UniversityAPI.Repositories.management_Repository;

namespace UniversityAPI.Services.studentservice
{
    public class StudentService : IStudentService
    {
        private readonly IManagementRepository<Student> _repo;
        public StudentService(IManagementRepository<Student> repo)
        {
            _repo = repo;
        }
        public async Task<List<StudentResponseDTOs>> GetAllStudentAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(s => new StudentResponseDTOs
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Gender = s.Gender,
                Department = s.Department
            }).ToList();
        }
        public async Task<StudentResponseDTOs?> GetStudentByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student != null)
            {
                return new StudentResponseDTOs()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Gender = student.Gender,
                    Department = student.Department
                };
            }
            return null;
        }
        public async Task AddStudentAsync(CreateStudentDTOs dto)
        {
            var student = new Student()
            {
                Name = dto.Name,
                Age = dto.Age,
                Department = dto.Department,
                Gender = dto.Gender,
            };
            await _repo.AddAsync(student);
        }
        public async Task UpdateStudentAsync(int id, CreateStudentDTOs dto)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student != null)
            {
                student.Name = dto.Name;
                student.Age = dto.Age;
                student.Department = dto.Department;
                student.Gender = dto.Gender;
                await _repo.UpdateAsync(student);
            }
        }
        public async Task RemoveStudentAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student != null)
            {
                await _repo.DeleteAsync(student.Id);
            }
        }
    }
}
