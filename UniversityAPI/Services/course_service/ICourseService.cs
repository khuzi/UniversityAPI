using UniversityAPI.DTOs.Course;

namespace UniversityAPI.Services.course_service
{
    public interface ICourseService
    {
        Task<List<CourseResponseDTOs>> GetAllCoursesAsync();
        Task<CourseResponseDTOs?> GetCourseById(int id);
        Task AddCourseAsync(CreateCourseDTOs dto);
        Task UpdateCourseAsync(CreateCourseDTOs dto, int id);
        Task AssignTeacherToCourse(int courseId, int teacherId);
        Task RemoveTeacherFromCourse(int courseId, int teacherId);
        Task EnrollStudentToCourse(int courseId, int studentId);
        Task RemoveStudentFromCourse(int courseId, int studentId);
    }
}
