using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs.Staff;
using UniversityAPI.Services.staffservice;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _service;

        public StaffController(IStaffService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffs = await _service.GetAllStaffAsync();
            return Ok(staffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _service.GetStaffByIdAsync(id);
            if (staff == null) return NotFound($"Staff with ID {id} not found.");
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStaffDTOs dto)
        {
            await _service.AddStaffAsync(dto);
            return Ok("Staff added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateStaffDTOs dto)
        {
            var result = await _service.UpdateStaffAsync(dto, id);
            if (!result) return NotFound($"Staff with ID {id} not found.");
            return Ok("Staff updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveStaffAsync(id);
            if (!result) return NotFound($"Staff with ID {id} not found.");
            return Ok("Staff deleted successfully.");
        }
    }
}
