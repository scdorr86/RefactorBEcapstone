using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RefactorBEcapstone.List.Requests;
using RefactorBEcapstone.List.Responses;
using RefactorBEcapstone.Models;
using RefactorBEcapstone.Repositories;

namespace RefactorBEcapstone.Service
{
    public class ListService : IListService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ChristmasList> _listRepo;
        private readonly IGenericRepository<AppUser> _userRepo;
        private readonly IGenericRepository<Models.Gift> _giftListRepo;

        public ListService(IMapper mapper, IGenericRepository<ChristmasList> listRepo, IGenericRepository<AppUser> userRepo, IGenericRepository<Models.Gift> giftListRepo)
        {
            _mapper = mapper;
            _listRepo = listRepo;
            _userRepo = userRepo;
            _giftListRepo = giftListRepo;
        }

        public async Task<ListResponse> CreateChristmasList(CreateListRequest listRequest)
        {
            var newList = _mapper.Map<ChristmasList>(listRequest);

            var result = await _listRepo.AddAsync(newList);
            var mappedResult = _mapper.Map<ListResponse>(result);
            return mappedResult;
        }

        public async Task<ListResponse> UpdateList(int listId, UpdateListRequest request)
        {
            var listToUpdate = await _listRepo.GetByIdAsync(x => x.Id == listId);

            if(listToUpdate == null)
            {
                throw new ApplicationException("List not found");
            }

            listToUpdate.ListName = !string.IsNullOrEmpty(request.ListName) ? request.ListName : listToUpdate.ListName;
            listToUpdate.ChristmasYearId = request.ChristmasYearId != null && request.ChristmasYearId != 0 ? request.ChristmasYearId : listToUpdate.ChristmasYearId;
            listToUpdate.GifteeId = request.GifteeId != null && request.GifteeId != 0 ? request.GifteeId : listToUpdate.GifteeId;

            await _listRepo.Update(listToUpdate);
            return _mapper.Map<ListResponse>(listToUpdate);
        }

        public async Task<List<ListResponse>> GetAllLists()
        {
            var lists = await _listRepo.GetAllAsync(query => query.Include(l => l.Gifts));
            return _mapper.Map<List<ListResponse>>(lists);

        }

        public async Task<ListResponse> GetListById(int id)
        {
            var list = await _listRepo.GetByIdAsync(
                x => x.Id == id,
                    query => query.Include(l => l.Gifts));

            if(list == null) { throw new ApplicationException("List not found, please try again."); }

            return _mapper.Map<ListResponse>(list);  
        }

        public async Task<ListResponse> SoftDeleteList(int listId)
        {
            var listToDelete = await _listRepo.GetByIdAsync(x => x.Id == listId);

            if (listToDelete == null) throw new ApplicationException("List not found, please try again.");

            var deletedList = await _listRepo.SoftDelete(listToDelete);

            return _mapper.Map<ListResponse>(deletedList);
        }

        public async Task<ListResponse> AddGiftToList(int listId, int giftId)
        {
            var list = await _listRepo.GetByIdAsync(
                x => x.Id == listId, 
                    query => query.Include(l => l.Gifts));
            var gift = await _giftListRepo.GetByIdAsync(x => x.Id == giftId);

            if (list == null) throw new ApplicationException("List not found, please try again.");
            if (gift == null) throw new ApplicationException("Gift not found, please try another.");

            list.Gifts.Add(gift);
            
            await _listRepo.Update(list);

            return _mapper.Map<ListResponse>(list);
        }
    }
}
