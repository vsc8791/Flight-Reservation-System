using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

namespace IACSD_MS.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(SubjectDAL.GetAll());
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // SubjectDAL.Get(id);
            return View(SubjectDAL.Get(id));
        }

        public ActionResult SubjectDetails()
        {
            if ( Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(SubjectDAL.GetAll());
        }

        public ActionResult SubjectForFaculty()
        {
            //if (Session["faculty"] == null )
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View(SubjectDAL.GetAll());
        }
        // GET: Subject/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            try
            {
                SubjectDAL.Insert(subject);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Subject());
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Subject sub)
        {
            try
            {
                // TODO: Add update logic here
                SubjectDAL.Update(sub);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Subject sub)
        {
            try
            {
                // TODO: Add delete logic here
                SubjectDAL.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
