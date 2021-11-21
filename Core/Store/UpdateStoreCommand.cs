using Core.Dtos;
using Data.Models;
using Data.Repositories;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Core.Commands{
    public class UpdateStoreCommand{
        public StoreDto Store {get;set;}
    }
    public class UpdateStoreCommandHandler{
        private readonly IRepository<Store,long> _storeRepository;
        public UpdateStoreCommandHandler(
            IRepository<Store,long> storeRepository
        ){
            _storeRepository = storeRepository;
        }

        public async Task<StoreDto> Handle(UpdateStoreCommand command){
            var dto = command.Store;
            bool storeAlreadyExist = _storeRepository.Find(x => x.Id == dto.Id).Any();
            if(!storeAlreadyExist){
                throw new Exception($"Store {dto.Name} Not Exist!");
            }

            var model = dto.AsModel();
            _storeRepository.Update(model);
            await Task.CompletedTask;
            return model.AsDto();
        }
        
    }
}