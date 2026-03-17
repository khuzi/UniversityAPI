using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Student;
using UniversityAPI.Models;
using UniversityAPI.Services.studentservice;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var student = await _service.GetAllStudentAsync();
            if (student == null) { return NotFound("NOT FOUND."); }
            return Ok(student);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) { return NotFound("NOT FOUND."); }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentDTOs dto)
        {
            await _service.AddStudentAsync(dto);
            return Ok($"Student {dto.Name} is added.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateStudentDTOs dto)
        {
            await _service.UpdateStudentAsync(id, dto);
            return Ok($"Student {dto.Name} is updated.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            await _service.RemoveStudentAsync(id);
            return Ok($"Student {student.Name} is deleted.");
        }
    }
}
