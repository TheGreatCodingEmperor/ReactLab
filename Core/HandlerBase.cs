using Data.Models;
using Data.Repositories;

namespace Core{
    public abstract class HandlerBase{
        protected readonly IRepository<Store,long> _storeRepository;
        protected HandlerBase(
            IRepository<Store,long> storeRepository
        ){
            _storeRepository = storeRepository;
        }
    }
}