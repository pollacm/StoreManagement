using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;

namespace StoreManagement.Repository.Stores
{
    public interface IStoreRepository
    {
        IQueryable<Store> GetAllStores();
        void AddStore(Store store);
        void SaveStream(ExcelPackage excelPackage, MemoryStream stream);
        void LoadPackage(ExcelPackage package, HttpPostedFileBase file);
    }
}
