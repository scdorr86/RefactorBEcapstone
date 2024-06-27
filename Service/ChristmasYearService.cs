using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<YearResponse>> GetAllYears()
        {
            var years = await _yearRepo.GetAllAsync();
            return _mapper.Map<List<YearResponse>>(years);
        }

        public async Task<YearResponse> UpdateYear(int yearId, UpdateYearRequest request)
        {
            var yearToUpdate = await _yearRepo.GetByIdAsync(x => x.Id == yearId);

            if(yearToUpdate == null)
            {
                throw new ApplicationException("Christmas Year Not Found.");
            }

            yearToUpdate.ListYear = !string.IsNullOrEmpty(request.ListYear) ? request.ListYear : yearToUpdate.ListYear;
            yearToUpdate.YearBudget = request.YearBudget.HasValue ? request.YearBudget.Value : yearToUpdate.YearBudget;

            await _yearRepo.Update(yearToUpdate);

            return _mapper.Map<YearResponse>(yearToUpdate);
        }

        public async Task<YearResponse> GetYearById(int yearId)
        {
            var year = await _yearRepo.GetByIdAsync(x => x.Id == yearId,
                include: source => source.Include(x => x.ChristmasLists));

            if (year == null) { throw new ApplicationException("Year Not Found. Please Try Again."); }

            return _mapper.Map<YearResponse>(year);
        }

        public async Task<YearResponse> SoftDeleteYear(int yearId)
        {
            var yearToDelete = await _yearRepo.GetByIdAsync(y => y.Id == yearId);

            if (yearToDelete == null) throw new ApplicationException("Year Not Found. Please Try Again.");

            var deletedYear = await _yearRepo.SoftDelete(yearToDelete);

            return _mapper.Map<YearResponse>(yearToDelete);
        }
    }
}
