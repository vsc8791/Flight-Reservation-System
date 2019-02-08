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
    public class StudentController : Controller

    {
        public ActionResult StudentLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(string uname,string psw)
        {
            Student stud =  StudentDAL.GetUserName(uname,psw);
            try
            {
                Session["student"]= stud.UserName;
                if (stud.UserName == uname && stud.Password == psw)
                {
                    return RedirectToAction(stud.PRNNumber, "Student/StudentDetailsForAdmin");
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
          
        


        // GET: Student
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(StudentDAL.GetAll());
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }


            return View(StudentDAL.Get(id));
        }
        //GET:Student/StudentDetailsForAdmin/5
        public ActionResult StudentDetailsForAdmin(string id)
        {
            if (Session["student"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(StudentDAL.Get(id));
        }
        // GET: Student/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //GET: Student Registration
        public ActionResult StudentRegistration()
        {
           
            return View();
        }
        //POST : Student Registration
        [HttpPost]
        public ActionResult StudentRegistration(Student student)
        {
            
            try
            {
                // TODO: Add insert logic here
                StudentDAL.Insert(student);
               
                bool status = sendEmail(student.Email, "Confirmation-New User Registration", "Dear " + student.FirstName + ",<br><br>Congratulations!! You are now registered as a student in IACSD.<br>Your Login ID & Password are:<br><br><b>Login ID :</b> " + student.UserName + "<br><b>Password :</b> " + student.Password + "<br><br>Regards,<br>IACSD");

                ViewData["RegistrationMsg"] = "Registration Successful";
                return View();
            }
            catch
            {
                ViewData["RegistrationMsg"] = "Sorry,Registration Not Done!!";
                return View();
            }
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add insert logic here
                StudentDAL.Insert(student);
                bool status = sendEmail(student.Email, "Confirmation-New User Registration", "Dear " + student.FirstName + ",<br><br>Congratulations!! You are now registered as a student in IACSD.<br>Your Login ID & Password are:<br><br><b>Login ID :</b> " + student.UserName + "<br><b>Password :</b> " + student.Password + "<br><br>Regards,<br>IACSD");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(StudentDAL.Get(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add update logic here
                if (StudentDAL.Update(student)) {
                    return RedirectToAction("Index");
                }


                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(StudentDAL.Get(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,Student student)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                // TODO: Add delete logic here
                StudentDAL.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool sendEmail(string toEmail,string subject,string emailBody)
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
