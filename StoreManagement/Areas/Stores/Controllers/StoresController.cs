using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Areas.Stores.Models;
using StoreManagement.Controllers;
using StoreManagement.Domain;
using StoreManagement.Repository.Stores;

namespace StoreManagement.Areas.Stores.Controllers
{
    public class StoresController : BaseController
    {
        //
        // GET: /Stores/
        public ActionResult Index()
        {
            var storeDomain = new StoreDomain(new StoreRepository(DataContext));
            var stores = storeDomain.GetAllOperationalActiveStores();
            return View(stores);
        }

        // GET: /Stores/Edit/5
        public ActionResult Edit(int id)
        {
            var storeDomain = new StoreDomain(new StoreRepository(DataContext));
            var storeDO = storeDomain.GetStore(id);

            var model = new StoreViewModel();
            model.Store = storeDO;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StoreViewModel model)
        {
            var storeDomain = new StoreDomain(new StoreRepository(DataContext));
            storeDomain.SaveStore(model.Store);

            DataContext.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult ExportExcel()
        {
            var storeDomain = new StoreDomain(new StoreRepository(DataContext));
            var stores = storeDomain.GetAllStores().ToList();
            var stream = storeDomain.GetExcelExportOfStores(stores);

            return File(stream, "application/vnd.ms-excel", "Stores.xlsx");
        }

        [HttpPost]
        public ActionResult ImportExcel(HttpPostedFileBase file)
        {
            //TODO: Need to do some validation on the document...
            if (!ModelState.IsValid)
            {
                throw new Exception("The file format is incorrect. Please verify and re-enter.");
            }

            var storeDomain = new StoreDomain(new StoreRepository(DataContext));
            storeDomain.ImportStoresExcel(file);

            DataContext.SaveChanges();

            //TODO: Could import this via an ajax method and reload the table dynamically
            return RedirectToAction("Index");
        }

        ////
        //// GET: /Stores/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Stores/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Stores/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Stores/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Stores/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
