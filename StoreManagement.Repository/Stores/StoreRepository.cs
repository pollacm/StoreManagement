using System;
using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;

namespace StoreManagement.Repository.Stores
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _db;

        public StoreRepository(DataContext db)
        {
            _db = db;
        }

        public IQueryable<Store> GetAllStores()
        {
            return _db.Stores;
        }

        public void AddStore(Store entity)
        {
            _db.Stores.Add(entity);
        }

        public void SaveStream(ExcelPackage excelPackage, MemoryStream stream)
        {
            excelPackage.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }

        public void LoadPackage(ExcelPackage package, HttpPostedFileBase file)
        {
            package.Load(file.InputStream);
        }
    }
}
