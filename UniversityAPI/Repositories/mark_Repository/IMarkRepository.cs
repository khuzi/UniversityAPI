using UniversityAPI.Models;

namespace UniversityAPI.Repositories.mark_Repository
{
    public interface IMarkRepository
    {
        Task AddAsync(Mark mark);
        Task<List<Mark>> GetStudentById(int studentId);
        Task RemoveAsync(int id);
        Task UpdateMarkAsync(Mark mark);

    }
}
