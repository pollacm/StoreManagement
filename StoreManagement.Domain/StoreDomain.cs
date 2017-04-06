using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using StoreManagement.Domain.Mappers;
using StoreManagement.Domain.Objects;
using StoreManagement.Repository.Stores;

namespace StoreManagement.Domain
{
    public class StoreDomain
    {
        private readonly IStoreRepository _repo;
        public StoreDomain(IStoreRepository repo)
        {
            _repo = repo;
        }

        public StoreDO GetStore(int id)
        {
            return StoreDomainMappers.MapEntityToDO(GetStoreEntity(id));
        }
        
        public List<StoreDO> GetAllStores()
        {
            return _repo.GetAllStores().Select(StoreDomainMappers.MapEntityToDO).ToList();
        }

        public List<StoreDO> GetAllOperationalActiveStores()
        {
            return _repo.GetAllStores().Where(s => s.Status == StoreDO.StoreStatus.Operational).Select(StoreDomainMappers.MapEntityToDO).ToList();
        }

        public void SaveStore(StoreDO model)
        {
            var entity = GetStoreEntity(model.StoreID);
            StoreDomainMappers.MapDOToEntity(model, entity);
        }

        public MemoryStream GetExcelExportOfStores(List<StoreDO> stores)
        {
            MemoryStream stream = new MemoryStream();

            using (ExcelPackage p = new ExcelPackage())
            {
                ExcelWorksheet ws = p.Workbook.Worksheets.Add("Stores");

                int row = 1, column = 1;

                ws.Column(column).Width = 25;
                ws.Cells[row, column++].Value = "Store ID";
                ws.Column(column).Width = 30;
                ws.Cells[row, column++].Value = "Name";
                ws.Column(column).Width = 25;
                ws.Cells[row, column++].Value = "Store Number";
                ws.Column(column).Width = 15;
                ws.Cells[row, column++].Value = "Address 1";
                ws.Column(column).Width = 15;
                ws.Cells[row, column++].Value = "Address 2";
                ws.Column(column).Width = 15;
                ws.Cells[row, column++].Value = "City";
                ws.Column(column).Width = 7;
                ws.Cells[row, column++].Value = "State";
                ws.Column(column).Width = 7;
                ws.Cells[row, column++].Value = "Zip";
                ws.Column(column).Width = 20;
                ws.Cells[row, column++].Value = "Status";

                ws.Cells["A1:AZ1"].Style.Font.Bold = true;

                foreach (var store in stores)
                {
                    row++;
                    column = 1;

                    ws.Cells[row, column++].Value = store.StoreID;
                    ws.Cells[row, column++].Value = store.Name;
                    ws.Cells[row, column++].Value = store.StoreNumber;
                    ws.Cells[row, column++].Value = store.Address1;
                    ws.Cells[row, column++].Value = store.Address2;
                    ws.Cells[row, column++].Value = store.City;
                    ws.Cells[row, column++].Value = store.State;
                    ws.Cells[row, column++].Value = store.Zipcode;
                    ws.Cells[row, column++].Value = store.Status;
                }

                _repo.SaveStream(p, stream);
            }

            return stream;
        }

        //TODO: need to think through these tests a little more...
        public void ImportStoresExcel(HttpPostedFileBase file)
        {
            using (var package = new ExcelPackage())
            {
                _repo.LoadPackage(package, file);

                foreach (var sheet in package.Workbook.Worksheets)
                {
                    for (int rowNum = 2; rowNum <= sheet.Dimension.End.Row; rowNum++)
                    {
                        int column = 1;
                        var store = new Store();

                        //TODO: Could also verify in the header row what index column each field is on to make for flexible

                        if (SheetIsCompleted(sheet, rowNum))
                        {
                            break;
                        }

                        store.Name = sheet.Cells[rowNum, column++].Text;
                        store.StoreNumber = sheet.Cells[rowNum, column++].Text;
                        store.Address1 = sheet.Cells[rowNum, column++].Text;
                        store.Address2 = sheet.Cells[rowNum, column++].Text;
                        store.City = sheet.Cells[rowNum, column++].Text;
                        store.State = sheet.Cells[rowNum, column++].Text;
                        store.Zipcode = sheet.Cells[rowNum, column++].Text;
                        store.Status = (StoreDO.StoreStatus)Enum.Parse(typeof(StoreDO.StoreStatus), sheet.Cells[rowNum, column++].Text);

                        _repo.AddStore(store);
                    }
                }
            }
        }

        //TODO: Implement filtering
        public List<StoreDO> GetStoresByNameFilter(string name)
        {
            throw new NotImplementedException();
        }

        public Store GetStoreEntity(int id)
        {
            return _repo.GetAllStores().SingleOrDefault(s => s.StoreID == id);
        }

        public bool SheetIsCompleted(ExcelWorksheet sheet, int rowNumber)
        {
            return string.IsNullOrEmpty(sheet.Cells[rowNumber, 1].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 2].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 3].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 4].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 5].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 6].Text) &&
                   string.IsNullOrEmpty(sheet.Cells[rowNumber, 7].Text);
        }
    }
}
