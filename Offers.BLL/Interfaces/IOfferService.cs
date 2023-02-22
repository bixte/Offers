using Offers.BLL.DTO;

namespace Offers.BLL.Interfaces
{
    public interface IOfferServiceAsync
    {
        public Task SaveFromOriginAsync(string originURL, string id);
        public Task<OfferDTO> GetOfferAsync(int id);
        public Task AddOfferAsync(OfferDTO offerDTO);
    }
}
