namespace Offers.DAL.Entities
{
    public class Category : EntityBase<int>
    {
        public IEnumerable<SubCategory> SubCategories { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}