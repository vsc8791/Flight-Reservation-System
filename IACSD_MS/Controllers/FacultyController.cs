using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

using System.Net.Mail;
using System.Net;
using System.Text;


namespace IACSD_MS.Controllers
{
    public class FacultyController : Controller
    {

        public ActionResult FacultyLogin()
        {


            return View();
        }

        [HttpPost]
        public ActionResult FacultyLogin(string uname, string psw)
        {
            Faculty adm = FacultyDAL.GetUserName(uname, psw);
            try
            {
                Session["faculty"]= adm.UserName;
               // string fac = (string)adm.FacultyId;
                if (adm.UserName == uname && adm.Password == psw)
                {
                    return RedirectToAction(adm.FacultyId.ToString(), "Faculty/FacultyDetailsForAll");
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
        // GET: Faculty
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(FacultyDAL.GetAll());
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            return View(FacultyDAL.Get(id));
        }

        public ActionResult FacultyDetailsForAll(int id)
        {
            if (Session["faculty"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(FacultyDAL.Get(id));
        }

        //GET: Faculty Registration
        public ActionResult FacultyRegistration()
        {

            return View();
        }
        //POST : Faculty Registration
        [HttpPost]
        public ActionResult FacultyRegistration(Faculty faculty)
        {

            try
            {
                // TODO: Add insert logic here
                FacultyDAL.Insert(faculty);
                bool status = sendEmail(faculty.Email, "Confirmation-New User Registration", "Dear " + faculty.FirstName + ",<br><br>Congratulations!! You are now registered as a faculty in IACSD.<br>Your Login ID & Password are:<br><br><b>Login ID :</b> " + faculty.UserName + "<br><b>Password :</b> " + faculty.Password + "<br><br>Regards,<br>IACSD");

                ViewData["RegistrationMsg"] = "Registration Successful";
                return View();
            }
            catch
            {
                ViewData["RegistrationMsg"] = "Sorry,Registration Not Done!!";
                return View();
            }
        }


        // GET: Faculty/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        public ActionResult Create(Faculty faculty)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            try
            {
                // TODO: Add insert logic here
                FacultyDAL.Insert(faculty);
                bool status = sendEmail(faculty.Email, "Confirmation-New User Registration", "Dear " + faculty.FirstName + ",<br><br>Congratulations!! You are now registered as a faculty in IACSD.<br>Your Login ID & Password are:<br><br><b>Login ID :</b> " + faculty.UserName + "<br><b>Password :</b> " + faculty.Password + "<br><br>Regards,<br>IACSD");


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //GET:Faculty Index
        public ActionResult FacultyIndex()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(FacultyDAL.GetAll());
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // FacultyDAL.Update(Student stud);
            return View(FacultyDAL.Get(id));
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Faculty faculty)
        {
            try
            {
                if (Session["admin"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                // TODO: Add update logic here
                FacultyDAL.Update(faculty);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(FacultyDAL.Get(id));
        }

        // POST: Faculty/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Faculty faculty)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here
                FacultyDAL.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool sendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
