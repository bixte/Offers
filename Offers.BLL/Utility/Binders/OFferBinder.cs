using Offers.DAL.Entities;
using System.Xml.Linq;

namespace Offers.BLL.Utility.Binders
{
    public class OFferBinder : IOfferBinder
    {
        public Offer Bind(string bId, string type,string picture, string IsAvailable, string url, string price, string currencyId, string categoryId, string description, IEnumerable<XElement> otherAttributes)
        {
            if (int.TryParse(bId, out int bIdPrs) && bool.TryParse(IsAvailable, out bool IsAvailablePrs) && double.TryParse(price, out double pricePrs)  && int.TryParse(categoryId, out int categoryIdPrs))
            {
                return new Offer
                {
                    BId = bIdPrs,
                    Type = type,
                    IsAvailable = IsAvailablePrs,
                    Url = url,
                    Price = pricePrs,
                    Picture = picture,
                    CurrencyId = currencyId,
                    CategoryId = categoryIdPrs,
                    Description = description,
                    OfferAttribute = otherAttributes.Select(x => new OfferAttribute
                    {
                        Name = x.Name.ToString(),
                        Value = x.Value,
                    }).ToList()
                };
            }
            throw new Exception("error of binding");
        }
    }
}
