namespace Offers.DAL.Entities
{
    public class Offer:EntityBase<int>
    {
        public int BId { get; set; }
        public IQueryable<OfferAttribute> OfferAttribute { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public string Url { get; set; } = null!;
        public double Price { get; set; }
        public string Currency { get; set; } = null!;
        public string? Picture { get; set; }
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
