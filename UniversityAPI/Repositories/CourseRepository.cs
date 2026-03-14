using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class CourseRepository
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
                _context.CourseTeachers.Remove(courseId, teacherId);
            }
        }
    }
}
