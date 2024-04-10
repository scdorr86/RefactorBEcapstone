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
        private readonly IGenericRepository<AppUser> _userRepo;

        public ChristmasYearService(IMapper mapper, IGenericRepository<ChristmasYear> yearRepo, IGenericRepository<AppUser> userRepo)
        {
            _mapper = mapper;
            _yearRepo = yearRepo;
            _userRepo = userRepo;
        }

        public async Task<YearResponse> CreateChristmasYear(CreateYearRequest yearRequest)
        {
            var newYear = _mapper.Map<ChristmasYear>(yearRequest);
            

            var result = await _yearRepo.AddAsync(newYear);
            var mappedResult = _mapper.Map<YearResponse>(result);
            return mappedResult;
        }
    }
}
