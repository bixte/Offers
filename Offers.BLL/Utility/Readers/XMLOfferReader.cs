using System.Xml.Linq;
namespace Offers.BLL.Utility.Readers
{
    public class XMLOfferReader
    {
        public string Url { get; set; }

        public XMLOfferReader(string url)
        {
            Url = url;
        }
        public XElement Read(string id)
        {
            XDocument xdoc = XDocument.Load(Url);
            if (xdoc.Root == null)
                throw new Exception("not found");
            var result = xdoc.Root
                          .Element("shop")?
                          .Element("offers")?
                          .Elements("offer")?
                          .First(o => o.Attribute("bid")?.Value == id);
            return result ?? throw new Exception($"not found offer with id = {id}");
        }
    }
}
