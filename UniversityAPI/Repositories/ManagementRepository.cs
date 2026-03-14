using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;

namespace UniversityAPI.Repositories
{
    public class ManagementRepository<T>  where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbset;
        public ManagementRepository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
