using StoreManagement.Domain.Objects;
using StoreManagement.Repository.Stores;

namespace StoreManagement.Domain.Mappers
{
    //TODO: Write tests for these as well
    public static class StoreDomainMappers
    {
        public static StoreDO MapEntityToDO(Store store)
        {
            return new StoreDO
            {
                StoreID = store.StoreID,
                Name = store.Name,
                StoreNumber = store.StoreNumber,
                Address1 = store.Address1,
                Address2 = store.Address2,
                City = store.City,
                State = store.State,
                Zipcode = store.Zipcode,
                Status = store.Status
            };
        }

        public static Store MapDOToEntity(StoreDO store)
        {
            return new Store
            {
                StoreID = store.StoreID,
                Name = store.Name,
                StoreNumber = store.StoreNumber,
                Address1 = store.Address1,
                Address2 = store.Address2,
                City = store.City,
                State = store.State,
                Zipcode = store.Zipcode,
                Status = store.Status
            };
        }

        public static Store MapDOToEntity(StoreDO storeDO, Store store)
        {
            store.StoreID = storeDO.StoreID;
            store.Name = storeDO.Name;
            store.StoreNumber = storeDO.StoreNumber;
            store.Address1 = storeDO.Address1;
            store.Address2 = storeDO.Address2;
            store.City = storeDO.City;
            store.State = storeDO.State;
            store.Zipcode = storeDO.Zipcode;
            store.Status = storeDO.Status;

            return store;
        }
    }
}
