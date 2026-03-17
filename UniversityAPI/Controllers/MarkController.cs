using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Marks;
using UniversityAPI.Services.mark_service;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _service;
        public MarkController(IMarkService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> SetMark([FromBody] CreateMarkDTOs dto)
        {
            var (flag, message) = await _service.SetMarkByTeacher(dto);
            if (!flag)
            {
                return BadRequest(message);
            }
            else
            {
                return Ok(message);
            }
        }
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetMarksByStudent(int id)
        {
            var marks = await _service.GetMarksOfStudentAsync(id);
            if (marks.Count == 0)
            {
                return NotFound("No marks found for this student.");
            }
            else
            {
                return Ok(marks);
            }
        }
    }
}
