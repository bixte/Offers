using Offers.DAL.Entities;
using System.Xml.Linq;

namespace Offers.BLL.Utility.Binders
{
    public interface IOfferBinder
    {
        public Offer Bind(string bId, string type, string picture, string IsAvailable, string url, string price, string currencyId, string categoryId, string description, IEnumerable<XElement> otherAttributes);
    }
}
