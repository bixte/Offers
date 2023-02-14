namespace Offers.DAL.Intefaces.Repositories
{
    public interface IRepositoryAsync<T> : IRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task<T?> FindAsync(int id);
    }
}
