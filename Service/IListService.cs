using RefactorBEcapstone.List.Requests;
using RefactorBEcapstone.List.Responses;

namespace RefactorBEcapstone.Service
{
    public interface IListService
    {
        Task<ListResponse> CreateChristmasList(CreateListRequest listRequest);
        Task<ListResponse> UpdateList(int listId, UpdateListRequest updateListRequest);
        Task<List<ListResponse>> GetAllLists();
        Task<ListResponse> GetListById(int listId);
        Task<ListResponse> SoftDeleteList(int listId);
        Task<ListResponse> AddGiftToList(int listId, int giftId);
    }
}
