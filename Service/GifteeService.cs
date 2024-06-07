using AutoMapper;
using RefactorBEcapstone.Giftee.Requests;
using RefactorBEcapstone.Giftee.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Repositories;

namespace RefactorBEcapstone.Service
{
    public class GifteeService : IGifteeService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Models.Giftee> _gifteeRepo;
        private readonly IGenericRepository<AppUser> _userRepo;

        public GifteeService(IMapper mapper, IGenericRepository<Models.Giftee> gifteeRepo, IGenericRepository<AppUser> userRepo)
        {
            _mapper = mapper;
            _gifteeRepo = gifteeRepo;
            _userRepo = userRepo;
        }

        public async Task<List<GifteeResponse>> GetAllGiftees()
        {
            var giftees = await _gifteeRepo.GetAllAsync();
            return _mapper.Map<List<GifteeResponse>>(giftees);
        }

        public async Task<GifteeResponse> CreateGiftee(GifteeRequest request)
        {
            var newGiftee = _mapper.Map<Models.Giftee>(request);
            var result = await _gifteeRepo.AddAsync(newGiftee);
            var mappedResult = _mapper.Map<GifteeResponse>(result);
            return mappedResult;
        }

        public async Task<GifteeResponse> UpdateGiftee(int gifteeId, UpdateGifteeRequest request)
        {
            var gifteeToUpdate = await _gifteeRepo.GetByIdAsync(x => x.Id == gifteeId);

            if(gifteeToUpdate == null)
            {
                throw new ApplicationException("Giftee Not Found.");
            }

            gifteeToUpdate.FirstName = !string.IsNullOrEmpty(request.FirstName) ? request.FirstName : gifteeToUpdate.FirstName;
            gifteeToUpdate.LastName = !string.IsNullOrEmpty(request.LastName) ? request.LastName : gifteeToUpdate.LastName;

            await _gifteeRepo.Update(gifteeToUpdate);

            return _mapper.Map<GifteeResponse>(gifteeToUpdate);
        }

        public async Task<GifteeResponse> GetGifteeById(int id)
        {
            var giftee = await _gifteeRepo.GetByIdAsync(x => x.Id == id);

            if (giftee == null) throw new ApplicationException("Giftee Not Found.");

            return _mapper.Map<GifteeResponse>(giftee);
        }
    }
}
