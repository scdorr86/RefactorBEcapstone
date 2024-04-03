using AutoMapper;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Repositories;
using RefactorBEcapstone.Year.Requests;
using RefactorBEcapstone.Year.Responses;

namespace RefactorBEcapstone.Service
{
    public class ChristmasYearService : IChristmasYearService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ChristmasYear> _yearRepo;

        public ChristmasYearService(IMapper mapper, IGenericRepository<ChristmasYear> yearRepo)
        {
            _mapper = mapper;
            _yearRepo = yearRepo;
        }

        public async Task<YearResponse> CreateChristmasYear(CreateYearRequest yearRequest, string userId)
        {
            var newYear = _mapper.Map<ChristmasYear>(yearRequest);
            newYear.CreatedById = userId;
            newYear.UpdatedById = userId;

            var result = await _yearRepo.AddAsync(newYear);
            var mappedResult = _mapper.Map<YearResponse>(result);
            return mappedResult;
        }
    }
}
