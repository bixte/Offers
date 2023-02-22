using Microsoft.EntityFrameworkCore;
using Offers.DAL.DataBases;
using Offers.DAL.Entities;

namespace Offers.DAL.Implementations.EF
{
    public class OfferRepository : Repository<Offer>
    {
        private readonly OffersEF offersEF;

        public OfferRepository(OffersEF offersEF) : base(offersEF)
        {
            this.offersEF = offersEF;
        }
        public override Offer? Find(int id)
        {
            return offersEF.Offers.FirstOrDefault(o => o.BId == id);
        }
        public override async Task<Offer?> FindAsync(int id)
        {
            var offer = await offersEF.Offers.FirstOrDefaultAsync(o => o.BId == id);
            if (offer != null)
            {
                await offersEF.Entry(offer).Reference(o => o.Category).LoadAsync();
                await offersEF.Entry(offer).Collection(o => o.OfferAttribute).LoadAsync();
            }
            return offer;
        }
    }
}
