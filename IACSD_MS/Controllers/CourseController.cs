using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;


namespace IACSD_MS.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(CourseDAL.GetAll());
        }
        //GET: CourseForAll
        public ActionResult CourseForAll()
        {
            if (Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(CourseDAL.GetAll());
        }

        public ActionResult CourseForFaculty()
        {
            if (Session["faculty"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(CourseDAL.GetAll());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(CourseDAL.Get(id));
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add insert logic here
                CourseDAL.Insert(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(CourseDAL.Get(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add update logic here
                CourseDAL.Update(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(CourseDAL.Get(id));
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course course)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here
                CourseDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
