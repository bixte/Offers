using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Offers.BLL.Interfaces;
using Offers.BLL.Services;
using Offers.DAL.DataBases;
using Offers.DAL.Implementations.EF;
using Offers.DAL.Intefaces.IUnitOfWorks;

namespace Offers.BLL.Infrastructure
{
    public static class AppServices
    {
        public static void AddAppServices(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<OffersEF>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();
            services.AddScoped<IOfferServiceAsync,OfferService>();
        }
    }
}
