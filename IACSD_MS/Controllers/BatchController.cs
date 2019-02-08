using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace IACSD_MS.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(BatchDAL.GetAll());
        }
        //GET:BatchForAll
        public ActionResult BatchForAll()
        {
            if ( Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(BatchDAL.GetAll());
        }

        public ActionResult BatchForFaculty()
        {
            if (Session["faculty"] == null )
            {
                return RedirectToAction("Index", "Home");
            }
            return View(BatchDAL.GetAll());
        }
        // GET: Batch/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(BatchDAL.Get(id));
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Batch/Create
        [HttpPost]
        public ActionResult Create(Batch batch)
        {
            try
            {
                // TODO: Add insert logic here
                if (Session["admin"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                BatchDAL.Insert(batch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Batch/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(BatchDAL.Get(id));
        }

        // POST: Batch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Batch batch)
        {
            try
            {
                if (Session["admin"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                // TODO: Add update logic here
                BatchDAL.Update(batch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(BatchDAL.Get(id));
        }

        // POST: Batch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Batch batch)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
