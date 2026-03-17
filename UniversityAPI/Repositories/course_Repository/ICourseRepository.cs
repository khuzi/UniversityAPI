using UniversityAPI.Models;

namespace UniversityAPI.Repositories.course_Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task RemoveAsync(int id);
        Task AssignTeacherAsync(int courseId, int teacherId);
        Task RemoveTeacherAsync(int courseId, int teacherId);
        Task EnrollStudentAsync(int studentId, int courseId);
        Task RemoveStudentAsync(int studentId, int courseId);
        Task<bool> IsStudentEnrollToCourseAsync(int courseId, int studentId);
        Task<bool> IsTeacherAssignedToCourseAsync(int courseId, int teacherId);
    }
}
