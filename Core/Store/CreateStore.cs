using Core.Dtos;

namespace Core.Commands{
    public class CreateStore{
        public StoreDto Store {get;set;}
    }
    public class Handler(CreateStore command){
        
    }
}