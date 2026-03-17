using UniversityAPI.DTOs.Staff;
using UniversityAPI.DTOs.Student;
using UniversityAPI.DTOs.Teacher;
using UniversityAPI.Models;
using UniversityAPI.Repositories.management_Repository;

namespace UniversityAPI.Services.staffservice
{
    public class StaffService : IStaffService
    {
        private readonly IManagementRepository<Staff> _repo;
        public StaffService(IManagementRepository<Staff> repo)
        {
            _repo = repo;
        }
        public async Task<List<StaffResponseDTOs>> GetAllStaffAsync()
        {
            var staff = await _repo.GetAllAsync();
            return staff.Select(t => new StaffResponseDTOs
            {
                Id = t.Id,
                Name = t.Name,
                Age = t.Age,
                Gender = t.Gender,
            }).ToList();
        }
        public async Task<StaffResponseDTOs> GetStaffByIdAsync(int id)
        {
            var staff = await _repo.GetByIdAsync(id);
            if (staff != null)
            {
                return new StaffResponseDTOs
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    Age = staff.Age,
                    Gender = staff.Gender,
                    Salary = staff.Salary,
                };
            }
            return null;
        }
        public async Task AddStaffAsync(CreateStaffDTOs dto)
        {
            var staff = new Staff()
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                Salary = dto.Salary,
            };
            await _repo.AddAsync(staff);
        }
        public async Task<bool> UpdateStaffAsync(CreateStaffDTOs dto, int id)
        {
            var staff = await _repo.GetByIdAsync(id);
            if (staff != null)
            {
                staff.Name = dto.Name;
                staff.Age = dto.Age;
                staff.Gender = dto.Gender;
                staff.Salary = dto.Salary;
                await _repo.UpdateAsync(staff);
                return true;
            }
            return false;
        }
        public async Task<bool> RemoveStaffAsync(int id)
        {
            var staff = await _repo.GetByIdAsync(id);
            if (staff != null)
            {
                await _repo.DeleteAsync(staff.Id);
                return true;
            }
            return false;
        }
    }
}
