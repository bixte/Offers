using AutoMapper;
using Offers.BLL.DTO;
using Offers.BLL.Interfaces;
using Offers.BLL.Utility.Binders;
using Offers.BLL.Utility.OfferParser;
using Offers.BLL.Utility.Readers;
using Offers.DAL.Entities;
using Offers.DAL.Intefaces.IUnitOfWorks;

namespace Offers.BLL.Services
{
    public class OfferService : IOfferServiceAsync
    {
        private readonly IUnitOfWorkAsync unitOfWork;

        public OfferService(IUnitOfWorkAsync unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task SaveFromOriginAsync(string originURL, string id)
        {
            var reader = new XMLOfferReader(originURL);
            var xOffer = reader.Read(id);
            var offerParser = new XMLOfferParser(new OFferBinder());
            var offer = offerParser.Parse(xOffer);
            await unitOfWork.OfferRepository.AddAsync(offer);
            await unitOfWork.SaveAsync();
        }
        public async Task<OfferDTO> GetOfferAsync(int id)
        {
            var offer = await unitOfWork.OfferRepository.FindAsync(id);
            if (offer == null)
                throw new Exception("not found");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Offer, OfferDTO>()
                        .ForMember(o => o.Category, option => option.MapFrom(o => o.Category.Name))
                        .ForMember(o => o.Currency, option => option.MapFrom(o => o.Currency.Id));
                cfg.CreateMap<OfferAttribute, OfferAttributeDTO>();

            });
            var offerDTO = config.CreateMapper().Map<Offer, OfferDTO>(offer);
            return offerDTO;
        }

        public async Task AddOfferAsync(OfferDTO offerDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OfferDTO, Offer>());
            var offer = new Mapper(config).Map<OfferDTO, Offer>(offerDTO);
            await unitOfWork.OfferRepository.AddAsync(offer);
            await unitOfWork.SaveAsync();
        }
    }
}
