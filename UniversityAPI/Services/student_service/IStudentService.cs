using UniversityAPI.DTOs.Student;

namespace UniversityAPI.Services.studentservice
{
    public interface IStudentService
    {
        Task<List<StudentResponseDTOs>> GetAllStudentAsync();
        Task<StudentResponseDTOs?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(CreateStudentDTOs dto);
        Task UpdateStudentAsync(int id, CreateStudentDTOs dto);
        Task RemoveStudentAsync(int id);
    }
}
