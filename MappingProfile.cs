using AutoMapper;
using RefactorBEcapstone.Gift.Requests;
using RefactorBEcapstone.Gift.Responses;
using RefactorBEcapstone.List.Requests;
using RefactorBEcapstone.List.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Year.Requests;
using RefactorBEcapstone.Year.Responses;

namespace RefactorBEcapstone
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateYearMaps();
            CreateListMaps();
            CreateGiftMaps();
        }

        public void CreateYearMaps()
        {
            _ = CreateMap<ChristmasYear, YearResponse>();
            _ = CreateMap<CreateYearRequest, ChristmasYear>();
        }

        public void CreateListMaps()
        {
            _ = CreateMap<ChristmasList, ListResponse>();
            _ = CreateMap<CreateListRequest, ChristmasList>();
        }

        public void CreateGiftMaps()
        {
            _ = CreateMap<Models.Gift, GiftResponse>();
            _ = CreateMap<GiftRequest, Models.Gift>();
        }
    }
}
