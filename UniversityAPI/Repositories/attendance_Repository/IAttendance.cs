using UniversityAPI.Models;

namespace UniversityAPI.Repositories.attendance_Repository
{
    public interface IAttendanceRepository
    {
        Task AddAsync(Attendance attendance);
        Task<Attendance?> GetAttendanceByStudentAsync(int studentId, int courseId);
        Task<List<Attendance>> GetAttendancesAsync(int studentId);
        Task RemoveAsync(int id);
        Task UpdateAttendanceAsync(Attendance attendance);
    }
}
