using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

namespace IACSD_MS.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(string uname, string psw)
        {
            Admin adm = AdminDAL.GetUserName(uname, psw);
            try
            {
                if (adm.UserName == uname && adm.Password == psw)
                {
                    Session["admin"]= adm.UserName;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewData["error"] = "INVALID LOGIN";
                }
            }
            catch (NullReferenceException ex)
            {
                ViewData["error"] = "INVALID LOGIN";
                return View();
            }
            return View();
        }

        public ActionResult DashBoard()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //GET: LOGOUT
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            ViewData["LogoutMessage"] = "SUCCESSFULLY LOGGED OUT";
            return RedirectToAction("Index", "Home");
        }
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(AdminDAL.GetAll());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(AdminDAL.Get(id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
                {
                    // TODO: Add insert logic here
                    AdminDAL.Insert(admin);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(AdminDAL.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Admin admin)
        {
            try
            {
                // TODO: Add update logic here
                if (Session["admin"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                AdminDAL.Update(admin);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(AdminDAL.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Admin admin)
        {
            try
            {
                if (Session["admin"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                // TODO: Add delete logic here
                AdminDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
