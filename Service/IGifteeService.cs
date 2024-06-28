using RefactorBEcapstone.Giftee.Requests;
using RefactorBEcapstone.Giftee.Responses;

namespace RefactorBEcapstone.Service
{
    public interface IGifteeService
    {
        Task<GifteeResponse> CreateGiftee(GifteeRequest request);
        Task<List<GifteeResponse>> GetAllGiftees();
        Task<GifteeResponse> GetGifteeById(int id);
        Task<GifteeResponse> UpdateGiftee(int id, UpdateGifteeRequest request);
        Task<GifteeResponse> SoftDeleteGiftee(int id);
    }
}
