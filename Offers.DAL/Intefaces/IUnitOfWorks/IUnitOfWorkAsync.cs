using Offers.DAL.Entities;
using Offers.DAL.Intefaces.Repositories;

namespace Offers.DAL.Intefaces.IUnitOfWorks
{
    public interface IUnitOfWorkAsync
    {
        public IRepositoryAsync<Offer> OfferRepository { get; }
        public Task SaveAsync();
    }
}
