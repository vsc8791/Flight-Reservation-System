using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

namespace IACSD_MS.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ScheduleDAL.GetAll());
        }
        //GET:Schedule/SchdeuleForFaculty
        public ActionResult ScheduleForAll()
        {
            if ( Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ScheduleDAL.GetAll());
        }

        public ActionResult ScheduleForFaculty()
        {
            if (Session["faculty"] == null )
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ScheduleDAL.GetAll());
        }
        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ScheduleDAL.Get(id));
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add insert logic here
                ScheduleDAL.Insert(schedule);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ScheduleDAL.Get(id));
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Schedule schedule)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add update logic here
                ScheduleDAL.Update(schedule);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ScheduleDAL.Get(id));
        }

        // POST: Schedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Schedule schedule)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here
                ScheduleDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
