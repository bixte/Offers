namespace Offers.DAL.Intefaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public T? Find(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAll(Func<T,bool> predicate);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteById(int id);
    }
}