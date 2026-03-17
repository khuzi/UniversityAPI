using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories.mark_Repository
{
    public class MarkRepository : IMarkRepository
    {
        private readonly AppDbContext _context;
        public MarkRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Mark mark)
        {
            await _context.Marks.AddAsync(mark);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Mark>> GetStudentById(int studentId)
        {
            return await _context.Marks
                .Include(m => m.Enrollment)
                .Where(m => m.StudentId == studentId)
                .ToListAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var exists = await _context.Marks.FindAsync(id);
            if (exists != null)
            {
                _context.Marks.Remove(exists);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateMarkAsync(Mark mark)
        {
            _context.Marks.Update(mark);
            await _context.SaveChangesAsync();
        }
    }
}
