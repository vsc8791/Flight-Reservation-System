using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

namespace IACSD_MS.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()

        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ResultDAL.GetAll());
        }
        //GET: ResultForAllStudent
        public ActionResult ResultForAllStudent()
        {
            if (Session["faculty"] == null || Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ResultDAL.GetAll());
        }

        // GET: Result/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ResultDAL.Get(id));
        }
        public ActionResult GetResult()
        {

            return View();
        }
        //public ActionResult StudentLogin(string uname, string psw)
        //{
        //    Student stud = StudentDAL.GetUserName(uname, psw);
        //    try
        //    {
        //        if (stud.UserName == uname && stud.Password == psw)
        //        {
        //            return RedirectToAction(stud.PRNNumber, "Student/Details");
        //        }
        //        else
        //        {
        //            ViewData["error"] = "INVALID LOGIN";
        //        }
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        ViewData["error"] = "INVALID LOGIN";
        //        return View();
        //    }
        //    return View();
        //}
        //POST:Get resulkt by prnnumber
        [HttpPost]
        public ActionResult GetResultByPRNNumber(string id)
        {
            if (Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ResultDAL.GetPRNNumber(id));
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        public ActionResult Create(Result result)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add insert logic here
                ResultDAL.Insert(result);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ResultDAL.Get(id));
        }

        // POST: Result/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Result result)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add update logic here
                if (ResultDAL.Update(result))
                {
                    return RedirectToAction("Index");
                    
                }
                // ResultDAL.Update(result);
                // return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Result/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Result result)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here
                ResultDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ResultDAL.Get(id));
            }
        }
    }
}
