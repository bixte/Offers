using Offers.DAL.Entities;
using Offers.DAL.Intefaces.Repositories;

namespace Offers.DAL.Intefaces.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        public IRepository<Offer> OfferRepository { get;}
        public void Save();
    }
}
