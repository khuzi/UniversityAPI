namespace UniversityAPI.Repositories
{
    public interface IManagementRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task SaveChangesAsync();
        Task DeleteAsync(int id);
    }
}
