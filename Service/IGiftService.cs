using RefactorBEcapstone.Gift.Requests;
using RefactorBEcapstone.Gift.Responses;

namespace RefactorBEcapstone.Service
{
    public interface IGiftService
    {
        Task<GiftResponse> CreateGift(GiftRequest request);
        Task<List<GiftResponse>> GetAllGifts();
        Task<GiftResponse> UpdateGift(int giftId, UpdateGiftRequest request);
    }
}
