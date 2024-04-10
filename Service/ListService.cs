﻿using AutoMapper;
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

        public ListService(IMapper mapper, IGenericRepository<ChristmasList> listRepo, IGenericRepository<AppUser> userRepo)
        {
            _mapper = mapper;
            _listRepo = listRepo;
            _userRepo = userRepo;
        }

        public async Task<ListResponse> CreateChristmasList(CreateListRequest listRequest)
        {
            var newList = _mapper.Map<ChristmasList>(listRequest);

            var result = await _listRepo.AddAsync(newList);
            var mappedResult = _mapper.Map<ListResponse>(result);
            return mappedResult;
        }
    }
}
