using RefactorBEcapstone.List.Requests;
using RefactorBEcapstone.List.Responses;

namespace RefactorBEcapstone.Service
{
    public interface IListService
    {
        Task<ListResponse> CreateChristmasList(CreateListRequest listRequest);
        Task<ListResponse> UpdateList(int listId, UpdateListRequest updateListRequest);
    }
}
