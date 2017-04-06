using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Domain.Objects;

namespace StoreManagement.Areas.Stores.Models
{
    public class StoreViewModel
    {
        public StoreDO Store { get; set; }
        public List<SelectListItem> Statuses
        {
            get
            {
                var statuses = new List<SelectListItem>();

                statuses.Add(new SelectListItem
                {
                    Text = "In Construction",
                    Value = StoreDO.StoreStatus.InConstruction.ToString()
                });

                statuses.Add(new SelectListItem
                {
                    Text = "Built",
                    Value = StoreDO.StoreStatus.Built.ToString()
                });

                statuses.Add(new SelectListItem
                {
                    Text = "Operational",
                    Value = StoreDO.StoreStatus.Operational.ToString()
                });

                statuses.Add(new SelectListItem
                {
                    Text = "Disabled",
                    Value = StoreDO.StoreStatus.Disabled.ToString()
                });

                return statuses;
            }
        }

    }
}