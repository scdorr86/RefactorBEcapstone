using AutoMapper;
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
    }
}
