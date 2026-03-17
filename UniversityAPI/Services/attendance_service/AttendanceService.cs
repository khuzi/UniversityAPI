using UniversityAPI.DTOs.Attendance;
using UniversityAPI.Models;
using UniversityAPI.Repositories.attendance_Repository;
using UniversityAPI.Repositories.course_Repository;

namespace UniversityAPI.Services.attendance_service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly ICourseRepository _courseRepo;
        public AttendanceService(IAttendanceRepository attendanceRepo,
            ICourseRepository courseRepo)
        {
            _attendanceRepo = attendanceRepo;
            _courseRepo = courseRepo;
        }
        public async Task<(bool success, string message)> MarkAttendanceByTeacherAsync
            (CreateAttendanceDTOs dto)
        {
            var teacherAssigned = await _courseRepo
                .IsTeacherAssignedToCourseAsync(dto.CourseId, dto.TeacherId);
            if (!teacherAssigned)
            {
                return (false, "Teacher is not assigned.");
            }
            var studentEnroll = await _courseRepo
                .IsStudentEnrollToCourseAsync(dto.CourseId, dto.StudentId);
            if (!studentEnroll)
            {
                return (false, "Student is not enroll to this course.");
            }
            var exists = await _attendanceRepo.GetAttendanceByStudentAsync(dto.StudentId, dto.CourseId);
            if (exists == null)
            {
                var attendance = new Attendance()
                {
                    DaysPresent = 1,
                    StudentId = dto.StudentId,
                    TeacherId = dto.TeacherId,
                    CourseId = dto.CourseId,
                };
                await _attendanceRepo.AddAsync(attendance);
                return (true, "Attendance marked for Day 1.");
            }
            else
            {
                exists.DaysPresent++;
                await _attendanceRepo.UpdateAttendanceAsync(exists);
                return (true, $"Attendance Marked. Total Days Present: {exists.DaysPresent}");
            }
        }
        public async Task<List<AttendanceResponseDTOs>> GetAttendanceByStudentAsync(int studentId)
        {
            var attendance = await _attendanceRepo.GetAttendancesAsync(studentId);
            return attendance.Select(a => new AttendanceResponseDTOs()
            {
                DaysPresent = a.DaysPresent,
            }).ToList();
        }
    }
}
