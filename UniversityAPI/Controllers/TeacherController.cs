using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Student;
using UniversityAPI.DTOs.Teacher;
using UniversityAPI.Models;
using UniversityAPI.Services.studentservice;
using UniversityAPI.Services.teacherservice;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teacher = await _service.GetAllTeachersAsync();
            if (teacher == null) { return NotFound("NOT FOUND"); }
            return Ok(teacher);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _service.GetTeacherById(id);
            if (teacher == null) { return NotFound("NOT FOUND"); }
            return Ok(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTeacherDTOs dto)
        {
            await _service.AddTeacherAsync(dto);
            return Ok($"Teacher {dto.Name} is added.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTeacherDTOs dto)
        {
            await _service.UpdateTeacherAsync(dto,id);
            return Ok($"Teacher {dto.Name} is updated.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _service.GetTeacherById(id);
            await _service.RemoveTeacherAsync(id);
            return Ok($"Teacher {teacher.Name} is remove.");
        }
    }
}
