using UniversityAPI.Data;
using UniversityAPI.DTOs.Teacher;
using UniversityAPI.Models;
using UniversityAPI.Repositories.management_Repository;

namespace UniversityAPI.Services.teacherservice
{
    public class TeacherService : ITeacherService
    {
        private readonly IManagementRepository<Teacher> _repo;
        public TeacherService(IManagementRepository<Teacher> repo)
        {
            _repo = repo;
        }
        // GET ALL=>>>>
        public async Task<List<TeacherResponseDTOs>> GetAllTeachersAsync()
        {
            var teacher = await _repo.GetAllAsync();
            return teacher.Select(t => new TeacherResponseDTOs
            {
                Id = t.Id,
                Name = t.Name,
                Age = t.Age,
                Gender = t.Gender,
            }).ToList();
        }

        // GET BY ID =>>>>
        public async Task<TeacherResponseDTOs?> GetTeacherById(int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            if (teacher != null)
            {
                return new TeacherResponseDTOs
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Age = teacher.Age,
                    Gender = teacher.Gender,
                };
            }
            return null;
        }

        // Add ==>>
        public async Task AddTeacherAsync(CreateTeacherDTOs dto)
        {
            var teacher = new Teacher()
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
            };
            await _repo.AddAsync(teacher);
        }

        // Update ===>>>
        public async Task UpdateTeacherAsync(CreateTeacherDTOs dto,int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            if(teacher != null)
            {
                teacher.Name = dto.Name;
                teacher.Age = dto.Age;
                teacher.Gender = dto.Gender;
                await _repo.UpdateAsync(teacher);
            }
        }

        // Delete ===>>>
        public async Task RemoveTeacherAsync(int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            if (teacher != null)
            {
                await _repo.DeleteAsync(teacher.Id);
            }
        }
    }
}
