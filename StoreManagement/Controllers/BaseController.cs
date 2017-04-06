using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Repository;

namespace StoreManagement.Controllers
{
    public class BaseController : Controller
    {
        public DataContext DataContext = new DataContext();
    }
}