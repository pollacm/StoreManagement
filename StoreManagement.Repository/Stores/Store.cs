using StoreManagement.Domain.Objects;

namespace StoreManagement.Repository.Stores
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string StoreNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public StoreDO.StoreStatus Status { get; set; }
    }
}
