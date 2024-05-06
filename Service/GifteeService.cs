using AutoMapper;
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
    }
}
