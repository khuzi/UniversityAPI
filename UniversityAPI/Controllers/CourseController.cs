using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Course;
using UniversityAPI.Repositories.course_Repository;
using UniversityAPI.Services.course_service;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var course = await _service.GetAllCoursesAsync();
            return Ok(course);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _service.GetCourseById(id);
            if (course == null) return NotFound($"Course with ID {id} not found.");
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCourseDTOs dto)
        {
            await _service.AddCourseAsync(dto);
            return Ok("Course added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateCourseDTOs dto)
        {
            await _service.UpdateCourseAsync(dto, id);
            return Ok("Course Updated.");
        }

        [HttpPost("assign-teacher")]
        public async Task<IActionResult> AssignTeacher(int courseId, int teacherId)
        {
            await _service.AssignTeacherToCourse(courseId, teacherId);
            return Ok("Teacher is assigned to course.");
        }
        
        [HttpDelete("remove-teacher")]
        public async Task<IActionResult> RemoveTeacher(int courseId, int teacherId)
        {
            await _service.RemoveTeacherFromCourse(courseId, teacherId);
            return Ok("Teacher is removed from the course.");
        }

        [HttpPost("enroll-student")]
        public async Task<IActionResult> EnrollStudent(int courseId, int studentId)
        {
            await _service.EnrollStudentToCourse(courseId, studentId);
            return Ok("Student is enrolled.");
        }

        [HttpDelete("remove-student")]
        public async Task<IActionResult> RemoveStudent(int courseId, int studentId)
        {
            await _service.RemoveStudentFromCourse(courseId, studentId);
            return Ok("Student is removed.");
        }
    }
}
