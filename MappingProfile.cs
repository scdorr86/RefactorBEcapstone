using AutoMapper;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Year.Responses;

namespace RefactorBEcapstone
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateYearMaps();
        }

        public void CreateYearMaps()
        {
            _ = CreateMap<ChristmasYear, YearResponse>();
        }
    }
}
