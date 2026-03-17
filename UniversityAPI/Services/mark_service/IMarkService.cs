using UniversityAPI.DTOs.Marks;

namespace UniversityAPI.Services.mark_service
{
    public interface IMarkService
    {
        Task<(bool flag, string message)> SetMarkByTeacher(CreateMarkDTOs dto);
        Task<List<MarkResponseDTOs>> GetMarksOfStudentAsync(int studentId);
    }
}
