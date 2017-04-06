using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using StoreManagement.Domain.Objects;

namespace StoreManagement.Domain.Tests
{
    [TestClass]
    public class StoreDomainTests
    {
        private StoreDomain StoreDomain { get; set; }
        private StoreRepositoryMock StoreRepository { get; set; }

        private List<StoreDO> _stores = new List<StoreDO>
        {
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
            new StoreDO
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
        
        [TestInitialize]
        public void Initialize()
        {
            StoreRepository = new StoreRepositoryMock();
            StoreDomain = new StoreDomain(StoreRepository);
        }

        [TestMethod]
        public void TestingGetAllOperationalStoresShouldOnlyReturnOperational()
        {
            var stores = StoreDomain.GetAllOperationalActiveStores();
            Assert.IsTrue(stores.All(s => s.Status == StoreDO.StoreStatus.Operational));
            Assert.IsTrue(StoreRepository.Messages.ContainsKey("GetAllStores"));
        }

        [TestMethod]
        public void TestingGetAllStoresShouldAllStores()
        {
            var stores = StoreDomain.GetAllStores();
            Assert.IsTrue(stores.Any(s => s.Status == StoreDO.StoreStatus.InConstruction));
            Assert.IsTrue(stores.Any(s => s.Status == StoreDO.StoreStatus.Built));
            Assert.IsTrue(stores.Any(s => s.Status == StoreDO.StoreStatus.Operational));
            Assert.IsTrue(stores.Any(s => s.Status == StoreDO.StoreStatus.Disabled));
            Assert.IsTrue(StoreRepository.Messages.ContainsKey("GetAllStores"));
        }

        [TestMethod]
        [Obsolete]
        public void TestShouldExportExcelDocument()
        {
            var excelPackage = StoreDomain.GetExcelExportOfStores(_stores);
            var ws = ((ExcelWorksheet)StoreRepository.Objects["Worksheet"]);

            var row = 2;
            foreach (var store in _stores)
            {
                var column = 1;

                Assert.AreEqual(ws.Cells[row, column++].Value, store.StoreID);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.Name);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.StoreNumber);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.Address1);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.Address2);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.City);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.State);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.Zipcode);
                Assert.AreEqual(ws.Cells[row, column++].Value, store.Status);

                row++;
            }

        }

        //TODO: Add tests for excel import... in interest of time will "pretend" those were added
    }
}
