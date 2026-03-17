using UniversityAPI.DTOs.Staff;

namespace UniversityAPI.Services.staffservice
{
    public interface IStaffService
    {
        Task<List<StaffResponseDTOs>> GetAllStaffAsync();
        Task<StaffResponseDTOs> GetStaffByIdAsync(int id);
        Task AddStaffAsync(CreateStaffDTOs dto);
        Task<bool> UpdateStaffAsync(CreateStaffDTOs dto, int id);
        Task<bool> RemoveStaffAsync(int id);
    }
}
