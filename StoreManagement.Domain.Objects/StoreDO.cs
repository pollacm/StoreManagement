using System.ComponentModel;
using Microsoft.Build.Framework;

namespace StoreManagement.Domain.Objects
{
    public class StoreDO
    {
        [DisplayName("Store ID")]
        public int StoreID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Store Number")]
        public string StoreNumber { get; set; }
        [DisplayName("Address 1")]
        public string Address1 { get; set; }
        [DisplayName("Address 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public StoreStatus Status { get; set; }

        public enum StoreStatus
        {
            InConstruction = 0,
            Built = 1,
            Operational = 2,
            Disabled = 3
        }
    }
}
