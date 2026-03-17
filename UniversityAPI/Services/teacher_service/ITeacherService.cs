using UniversityAPI.DTOs.Student;
using UniversityAPI.DTOs.Teacher;

namespace UniversityAPI.Services.teacherservice
{
    public interface ITeacherService
    {
        Task<List<TeacherResponseDTOs>> GetAllTeachersAsync();
        Task<TeacherResponseDTOs?> GetTeacherById(int id);
        Task AddTeacherAsync(CreateTeacherDTOs dto);
        Task UpdateTeacherAsync(CreateTeacherDTOs dto, int id);
        Task RemoveTeacherAsync(int id);
    }
}
