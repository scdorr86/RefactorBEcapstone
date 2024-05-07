using AutoMapper;
using RefactorBEcapstone.Gift.Requests;
using RefactorBEcapstone.Gift.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Repositories;

namespace RefactorBEcapstone.Service
{
    public class GiftService : IGiftService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Models.Gift> _giftRepo;
        private readonly IGenericRepository<AppUser> _userRepo;

        public GiftService(IMapper mapper, IGenericRepository<Models.Gift> giftRepo, IGenericRepository<AppUser> userRepo)
        {
            _mapper = mapper;
            _giftRepo = giftRepo;
            _userRepo = userRepo;
        }

        public async Task<GiftResponse> CreateGift(GiftRequest giftRequest)
        {
            var newGift = _mapper.Map<Models.Gift>(giftRequest);
            
            var result = await _giftRepo.AddAsync(newGift);
            var mappedResult = _mapper.Map<GiftResponse>(result);
            return mappedResult;
        }

        public async Task<List<GiftResponse>> GetAllGifts()
        {
            var gifts = await _giftRepo.GetAllAsync();
            return _mapper.Map<List<GiftResponse>>(gifts);
        }
    }
}
