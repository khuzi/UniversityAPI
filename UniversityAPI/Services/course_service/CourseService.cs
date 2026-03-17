using Microsoft.EntityFrameworkCore.ChangeTracking;
using UniversityAPI.DTOs.Course;
using UniversityAPI.Models;
using UniversityAPI.Repositories.course_Repository;
using UniversityAPI.Repositories.management_Repository;

namespace UniversityAPI.Services.course_service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        private readonly IManagementRepository<Student> _studentRepo;
        private readonly IManagementRepository<Teacher> _teacherRepo;
        public CourseService(ICourseRepository repo,
            IManagementRepository<Teacher> teacherRepo,
            IManagementRepository<Student> studentRepo)
        {
            _repo = repo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
        }

        public async Task<List<CourseResponseDTOs>> GetAllCoursesAsync()
        {
            var course = await _repo.GetAllAsync();
            return course.Select(c => new CourseResponseDTOs()
            {
                CourseName = c.CourseName,
                CreditHour = c.CreditHour,
            }).ToList();
        }
        public async Task<CourseResponseDTOs?> GetCourseById(int id)
        {
            var courses = await _repo.GetByIdAsync(id);
            if (courses != null)
            {
                return new CourseResponseDTOs()
                {
                    CourseName = courses.CourseName,
                    CreditHour = courses.CreditHour
                };
            }
            return null;
        }
        public async Task AddCourseAsync(CreateCourseDTOs dto)
        {
            var course = new Course()
            {
                CourseName = dto.CourseName,
                CreditHour = dto.CreditHour
            };
            await _repo.AddAsync(course);
        }
        public async Task UpdateCourseAsync(CreateCourseDTOs dto, int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course != null)
            {
                course.CourseName = dto.CourseName;
                course.CreditHour = dto.CreditHour;
                await _repo.UpdateCourseAsync(course);
            }
        }
        public async Task AssignTeacherToCourse(int courseId, int teacherId)
        {
            var teacher = await _teacherRepo.GetByIdAsync(teacherId);
            var course = await _repo.GetByIdAsync(courseId);
            if (course != null && teacherId != null)
            {
                await _repo.AssignTeacherAsync(courseId, teacherId);
            }
        }
        public async Task RemoveTeacherFromCourse(int courseId, int teacherId)
        {
            var teacher = await _teacherRepo.GetByIdAsync(teacherId);
            var course = await _repo.GetByIdAsync(courseId);
            if (course != null && teacher != null)
            {
                await _repo.RemoveTeacherAsync(courseId,teacherId);
            }
        }
        public async Task EnrollStudentToCourse(int courseId, int studentId)
        {
            var student = await _studentRepo.GetByIdAsync(studentId);
            var course = await _repo.GetByIdAsync(courseId);
            if (course != null && student != null)
            {
                await _repo.EnrollStudentAsync(studentId, courseId);
            }
        }
        public async Task RemoveStudentFromCourse(int courseId, int studentId)
        {
            var student = await _studentRepo.GetByIdAsync(studentId);
            var course = await _repo.GetByIdAsync(courseId);
            if (course != null && student != null)
            {
                await _repo.RemoveStudentAsync(studentId,courseId);
            }
        }
    }
}
