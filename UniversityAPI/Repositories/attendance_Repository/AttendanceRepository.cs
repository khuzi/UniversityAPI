using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories.attendance_Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;
        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Attendance>> GetAttendancesAsync(int studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentId == studentId)
                .ToListAsync();
        }
        public async Task<Attendance?> GetAttendanceByStudentAsync(int studentId, int courseId)
        {
            return await _context.Attendances
                .FirstOrDefaultAsync(cs =>
                cs.StudentId == studentId && cs.CourseId == courseId);
        }
        public async Task RemoveAsync(int id)
        {
            var exists = await _context.Attendances.FindAsync(id);
            if (exists != null)
            {
                _context.Attendances.Remove(exists);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
