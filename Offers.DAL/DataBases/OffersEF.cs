using Microsoft.EntityFrameworkCore;
using Offers.DAL.Entities;

namespace Offers.DAL.DataBases
{
    public class OffersEF : DbContext
    {
        public OffersEF(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
       public DbSet<Offer> Offers { get; set; }
    }
}