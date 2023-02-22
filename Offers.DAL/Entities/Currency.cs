namespace Offers.DAL.Entities
{
    public class Currency
    {
        public string Id { get; set; } = null!;
        public int Rate { get; set; }
        public int Plus { get; set; }
    }
}
