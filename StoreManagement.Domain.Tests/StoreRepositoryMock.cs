using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using StoreManagement.Domain.Objects;
using StoreManagement.Repository.Stores;

namespace StoreManagement.Domain.Tests
{
    public class StoreRepositoryMock : IStoreRepository
    {
        public Dictionary<string, string> Messages = new Dictionary<string, string>();
        public Dictionary<string, object> Objects = new Dictionary<string, object>();
        public ExcelPackage TestExcelPackage = new ExcelPackage 
        {
            
        };

        private readonly List<Store> _stores = new List<Store>
        {
            new Store
            {
                StoreID = 1,
                Name = "My Test Store 1",
                StoreNumber = "ABC123",
                Address1 = "123 6th St.",
                Address2 = "Suite 10",
                City = "Melbourne",
                State = "Florida",
                Zipcode = "32904",
                Status = StoreDO.StoreStatus.Built
            },
            new Store
            {
                StoreID = 2,
                Name = "My Test Store 2",
                StoreNumber = "DEF23",
                Address1 = "71 Pilgrim Avenue",
                City = "Chevy Chase",
                State = "Maryland",
                Zipcode = "20815",
                Status = StoreDO.StoreStatus.Disabled
            },
            new Store
            {
                StoreID = 3,
                Name = "My Test Store 2A",
                StoreNumber = "101-4",
                Address1 = "70 Bowman St.",
                Address2 = "Suite 10",
                City = "South Windsor",
                State = "CT",
                Zipcode = "06074",
                Status = StoreDO.StoreStatus.Operational
            },
            new Store
            {
                StoreID = 4,
                Name = "My Test Store 3",
                StoreNumber = "101A14",
                Address1 = "4 Goldfield Rd.",
                City = "Honolulu",
                State = "Hawaii",
                Zipcode = "96815",
                Status = StoreDO.StoreStatus.Operational
            },
            new Store
            {
                StoreID = 5,
                Name = "My Test Store 4",
                StoreNumber = "1234AAA",
                Address1 = "123 6th St.",
                Address2 = "Suite 10",
                City = "Melbourne",
                State = "Florida",
                Zipcode = "32904",
                Status = StoreDO.StoreStatus.InConstruction
            },
            new Store
            {
                StoreID = 6,
                Name = "My Test Store 5",
                StoreNumber = "BBB11",
                Address1 = "44 Shirley Ave.",
                City = "West Chicago",
                State = "Illinois",
                Zipcode = "60185",
                Status = StoreDO.StoreStatus.Operational
            },
            new Store
            {
                StoreID = 7,
                Name = "My Test Store 6",
                StoreNumber = "TTT345",
                Address1 = "514 S. Magnolia St.",
                City = "Orlando",
                State = "Florida",
                Zipcode = "32806",
                Status = StoreDO.StoreStatus.Operational
            },
            new Store
            {
                StoreID = 8,
                Name = "My Test Store 7",
                StoreNumber = "OIFK221",
                Address1 = "208 Harvard Road",
                City = "Dekalb",
                State = "Illinois",
                Zipcode = "60115",
                Status = StoreDO.StoreStatus.Built
            }
        };

        public IQueryable<Store> GetAllStores()
        {
            Messages.Add("GetAllStores", "Retrieved all stores");
            return _stores.AsQueryable();
        }

        public void AddStore(Store entity)
        {
            Messages.Add("AddStore", entity.StoreID.ToString());
            _stores.Add(entity);
        }

        public void SaveStream(ExcelPackage excelPackage, MemoryStream stream)
        {
            Objects.Add("WorkSheet", excelPackage);
        }

        public void LoadPackage(ExcelPackage package, HttpPostedFileBase file)
        {
            package = TestExcelPackage;
        }
    }
}
