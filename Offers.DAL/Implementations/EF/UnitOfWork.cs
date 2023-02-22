using Offers.DAL.DataBases;
using Offers.DAL.Entities;
using Offers.DAL.Intefaces.IUnitOfWorks;
using Offers.DAL.Intefaces.Repositories;

namespace Offers.DAL.Implementations.EF
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly OffersEF offersEF;
        private bool _disposedValue;
        public UnitOfWorkAsync(OffersEF offersEF)
        {
            this.offersEF = offersEF;
        }
        private OfferRepository? offerRepository;

        public IRepositoryAsync<Offer> OfferRepository
        {
            get => offerRepository ??= new OfferRepository(offersEF);
        }

        public async Task SaveAsync()
        {
            await offersEF.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    offersEF.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
