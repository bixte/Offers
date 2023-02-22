namespace Offers.DAL.Entities
{
    public class SubCategory : EntityBase<int>
    {
        public Category Parent { get; set; } = null!;
        public int ParentId { get; set; }
        public string Name { get; set; } = null!;
    }
}
