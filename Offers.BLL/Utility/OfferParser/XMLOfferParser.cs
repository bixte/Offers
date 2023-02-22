using Offers.BLL.Utility.Binders;
using Offers.DAL.Entities;
using System.Xml.Linq;

namespace Offers.BLL.Utility.OfferParser
{
    public class XMLOfferParser
    {
        private readonly IOfferBinder offerBinder;
        public XMLOfferParser(IOfferBinder offerBinder)
        {
            this.offerBinder = offerBinder;
        }
        public Offer Parse(XElement xOffer)
        {
            var bId = xOffer.Attribute("bid");
            var type = xOffer.Attribute("type");
            var available = xOffer.Attribute("available");
            var url = xOffer.Element("url");
            var price = xOffer.Element("price");
            var currencyId = xOffer.Element("currencyId");
            var categoryId = xOffer.Element("categoryId");
            var picture = xOffer.Element("picture");
            var description = xOffer.Element("description");
            if (bId != null && type != null && url != null && price != null && categoryId != null &&
                currencyId != null && picture != null && description != null && available != null)
            {
                var otherAttribute = xOffer.Elements().Except(new XElement[] { url, price, categoryId, currencyId, picture, description });

                var offer = offerBinder.Bind(bId.Value, type.Value,picture.Value, available.Value, url.Value, price.Value, currencyId.Value, categoryId.Value, description.Value, otherAttribute);
                return offer;
            }
            else
                throw new Exception("error of parse");
        }
    }
}
