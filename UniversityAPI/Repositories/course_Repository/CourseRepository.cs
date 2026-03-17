using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories.course_Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.CourseTeachers).ThenInclude(ct => ct.Teacher)
                .Include(c => c.Enrollments).ThenInclude(cs => cs.Student)
                .ToListAsync();
        }
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Enrollments).ThenInclude(cs => cs.Student)
                .Include(c => c.CourseTeachers).ThenInclude(ct => ct.Teacher)
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }
        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AssignTeacherAsync(int courseId, int teacherId)
        {
            // AnyAsync provide doest it exists or not means yes or no;
            var exists = await _context.CourseTeachers
                .AnyAsync(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);

            if (!exists)
            {
                await _context.CourseTeachers.AddAsync(new CourseTeacher
                {
                    CourseId = courseId,
                    TeacherId = teacherId
                });
                await _context.SaveChangesAsync();
            }
        }
        public async Task RemoveTeacherAsync(int courseId, int teacherId)
        {
            var exists = await _context.CourseTeachers
                .FirstOrDefaultAsync(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);

            if (exists != null)
            {
                _context.CourseTeachers.Remove(exists);
                await _context.SaveChangesAsync();
            }
        }
        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            var exists = await _context.Enrollments
                .AnyAsync(cs => cs.StudentId == studentId && cs.CourseId == courseId);

            if (!exists)
            {
                await _context.Enrollments.AddAsync(new Enrollment
                {
                    CourseId = courseId,
                    StudentId = studentId
                });
                await _context.SaveChangesAsync();
            }
        }
        public async Task RemoveStudentAsync(int studentId, int courseId)
        {
            var exists = await _context.Enrollments
                           .FirstOrDefaultAsync(cs => cs.StudentId == studentId && cs.CourseId == courseId);
            if (exists != null)
            {
                _context.Enrollments.Remove(exists);
                _context.SaveChangesAsync();
            }
        }
        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsTeacherAssignedToCourseAsync(int courseId, int teacherId)
        {
            return await _context.CourseTeachers
                .AnyAsync(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);
        }

        public async Task<bool> IsStudentEnrollToCourseAsync(int courseId, int studentId)
        {
            return await _context.Enrollments
                .AnyAsync(cs => cs.CourseId == courseId && cs.StudentId == studentId);
        }
    }
}
