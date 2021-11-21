using Core.Dtos;
using Data.Models;
using Data.Repositories;
using System.Linq;
using System;
using System.Threading.Tasks;
using Core.Commands;
using System.Collections.Generic;
using MediatR;
using System.Threading;

namespace Core.Queries{
    public class GetAllStoreQuery:IRequest<List<StoreDto>>{
        
    }
    public class GetStoreIdQuery:IRequest<StoreDto>{
        public long Id {get;set;}
    }
    public class GetStoreQueryHandler:
    HandlerBase,
    IRequestHandler<GetAllStoreQuery, List<StoreDto>>,
    IRequestHandler<GetStoreIdQuery, StoreDto>{
        public GetStoreQueryHandler(
            IRepository<Store,long> storeRepository
        ):base(storeRepository){
        }

        public async Task<List<StoreDto>> Handle(GetAllStoreQuery query, CancellationToken cancellationToken){
            await Task.CompletedTask;
            var result = _storeRepository.Find(x => true).Select(x => x.AsDto()).ToList();
            return result;
        }
 
        public async Task<StoreDto> Handle(GetStoreIdQuery query, CancellationToken cancellationToken){
            var id = query.Id;
            var model = _storeRepository.Find (x => x.Id == id).FirstOrDefault();
            if (model==null) {
                throw new Exception ($"Store Id={id} Not Exist!");
            }
            await Task.CompletedTask;
            var result = model.AsDto();
            return result;
        }
    }
}