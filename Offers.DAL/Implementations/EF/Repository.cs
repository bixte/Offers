using Offers.DAL.DataBases;
using Offers.DAL.Intefaces.Repositories;

namespace Offers.DAL.Implementations.EF
{
    public abstract class Repository<T> : IRepositoryAsync<T> where T : class
    {
        private readonly OffersEF offersEF;

        public Repository(OffersEF offersEF)
        {
            this.offersEF = offersEF;
        }
        public void Add(T entity)
        {
            offersEF.Set<T>().Add(entity);
            offersEF.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await offersEF.Set<T>().AddAsync(entity);
            await offersEF.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            offersEF.Set<T>().Remove(entity);
            offersEF.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = Find(id);
            if (entity == null)
                throw new Exception("not found");
            offersEF.Set<T>().Remove(entity);
        }

        virtual public T? Find(int id)
        {
            var entity = offersEF.Set<T>().Find(id);
            return entity;
        }

        virtual public async Task<T?> FindAsync(int id)
        {
            var entity = await offersEF.Set<T>().FindAsync(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return offersEF.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return offersEF.Set<T>().Where(predicate);
        }
        public void Update(T entity)
        {
            offersEF.Set<T>().Update(entity);
        }
    }
}
