using Offers.DAL.DataBases;
using Offers.DAL.Entities;

namespace Offers.DAL.Implementations.EF
{
    public class OfferRepository : Repository<Offer>
    {
        public OfferRepository(OffersEF offersEF) : base(offersEF)
        {
        }
    }
}
