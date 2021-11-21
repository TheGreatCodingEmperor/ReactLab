using Core.Dtos;
using Data.Models;

namespace Core {
    public static partial class Extension {
        public static StoreDto AsDto (this Store model) {
            return new StoreDto () {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                Type = model.Type,
                Day = model.Day,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Note = model.Note
            };
        }

        public static Store AsModel (this StoreDto dto) {
            return new Store () {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                Type = dto.Type,
                Day = dto.Day,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Note = dto.Note
            };
        }
    }
}