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

        public async Task<GiftResponse> UpdateGift(int giftId, UpdateGiftRequest request)
        {
            var giftToUpdate = await _giftRepo.GetByIdAsync(x => x.Id == giftId);

            if (giftToUpdate == null)
            {
                throw new ApplicationException("Gift not found.");
            }

            giftToUpdate.GiftName = !string.IsNullOrEmpty(request.GiftName) ? request.GiftName : giftToUpdate.GiftName;
            giftToUpdate.Price = request.Price.HasValue ? request.Price.Value : giftToUpdate.Price;
            giftToUpdate.ImageUrl = !string.IsNullOrEmpty(request.ImageUrl) ? request.ImageUrl : giftToUpdate.ImageUrl;
            giftToUpdate.OrderedFrom = !string.IsNullOrEmpty(request.OrderedFrom) ? request.OrderedFrom : giftToUpdate.OrderedFrom;

            return _mapper.Map<GiftResponse>(giftToUpdate);
        }
    }
}
