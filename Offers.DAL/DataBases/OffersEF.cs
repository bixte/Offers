using Microsoft.EntityFrameworkCore;
using Offers.DAL.Entities;

namespace Offers.DAL.DataBases
{
    public class OffersEF : DbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public OffersEF(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*in order to retrieve the data from the source, I have to do the initial initialization. But the data have a primary key, that not let init it elsewhere like here (although it is wrong).*/
            var category = new Category
            {
                Name = "Музыка и видеофильмы",
                Id = 4,
            };
            modelBuilder.Entity<Category>().HasData(category);
            modelBuilder.Entity<SubCategory>().HasData(new SubCategory { Name = "Музыка", Id = 17, ParentId = 4 });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = "RUR", Plus = 1, Rate = 0 });
            base.OnModelCreating(modelBuilder);
        }
    }
}