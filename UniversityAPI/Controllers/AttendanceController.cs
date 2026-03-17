using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Attendance;
using UniversityAPI.Services.attendance_service;
using UniversityAPI.Services.studentservice;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetAttendanceByStudent(int id)
        {
            var student = await _service.GetAttendanceByStudentAsync(id);
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> MarkAttendance([FromBody] CreateAttendanceDTOs dto)
        {
            var (success, message) = await _service.MarkAttendanceByTeacherAsync(dto);
            if (!success)
            {
                return BadRequest(message);
            }
            else
            {
                return Ok(message);
            }
        }
    }
}
