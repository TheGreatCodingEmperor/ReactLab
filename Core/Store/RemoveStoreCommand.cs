using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Data.Models;
using Data.Repositories;

namespace Core.Commands {
    public class RemoveStoreCommand {
        public long Id { get; set; }
    }
    public class RemoveStoreCommandHandler  {
        private readonly IRepository<Store,long> _storeRepository;
        public RemoveStoreCommandHandler (
            IRepository<Store,long> storeRepository
        ) {
            _storeRepository = storeRepository;
        }

        public async Task<bool> Handle (RemoveStoreCommand command) {
            var id = command.Id;
            bool storeAlreadyExist = _storeRepository.Find (x => x.Id == id).Any ();
            if (!storeAlreadyExist) {
                throw new Exception ($"Store Id={id} Not Exist!");
            }

            _storeRepository.Delete (id);
            await Task.CompletedTask;
            return true;
        }
    }
}