namespace Offers.DAL.Entities
{
    public class OfferAttribute:EntityBase<int>
    {
        public int OfferId { get; set; }
        public string Name { get; set; } = null!;
    }
}
