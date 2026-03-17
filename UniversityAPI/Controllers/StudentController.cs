using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Student;
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
            return Ok(await _service.GetAllStudentAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetStudentByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentDTOs dto)
        {
            await _service.AddStudentAsync(dto);
            return Ok($"Student {dto.Name} is added.");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateStudentDTOs dto)
        {
            await _service.UpdateStudentAsync(id, dto);
            return Ok($"Student {dto.Name} is added.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            await _service.RemoveStudentAsync(id);
            return Ok($"Student {student.Name} is added.");
        }
    }
}
