using Core.Dtos;
using Data.Models;
using Data.Repositories;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Core.Commands{
    public class CreateStoreCommand{
        public StoreDto Store {get;set;}
    }
    public class CreateStoreCommandHandler{
        private readonly IRepository<Store,long> _storeRepository;
        public CreateStoreCommandHandler(
            IRepository<Store,long> storeRepository
        ){
            _storeRepository = storeRepository;
        }

        public async Task<StoreDto> Handle(CreateStoreCommand command){
            var dto = command.Store;
            bool storeAlreadyExist = _storeRepository.Find(x => x.Name == dto.Name).Any();
            if(storeAlreadyExist){
                throw new Exception($"Store {dto.Name} Already Exist");
            }

            var model = dto.AsModel();
            _storeRepository.Create(model);
            await Task.CompletedTask;
            return model.AsDto();
        }
        
    }
}