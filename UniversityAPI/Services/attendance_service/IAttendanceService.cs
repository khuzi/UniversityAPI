using UniversityAPI.DTOs.Attendance;

namespace UniversityAPI.Services.attendance_service
{
    public interface IAttendanceService
    {
        Task<(bool success, string message)> MarkAttendanceByTeacherAsync(CreateAttendanceDTOs dto);
        Task<List<AttendanceResponseDTOs>> GetAttendanceByStudentAsync(int studentId);
    }
}
