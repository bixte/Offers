namespace Offers.DAL.Entities
{
    public class Offer:EntityBase<int>
    {
        public int BId { get; set; }
        public IEnumerable<OfferAttribute> OfferAttribute { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public string Url { get; set; } = null!;
        public double Price { get; set; }
        public Currency Currency { get; set; } = null!;
        public string CurrencyId { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public SubCategory Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
    }
}
