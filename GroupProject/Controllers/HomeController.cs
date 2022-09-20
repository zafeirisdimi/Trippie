using GroupProject.Database;
using GroupProject.Models;
using GroupProject.Models.Dtos;
using GroupProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository userRepo;

        public HomeController()
        {
            _context = new ApplicationDbContext();

            userRepo = new UserRepository(_context);
        }



        public ActionResult Index(bool? paymentSuccess)
        {
            if (paymentSuccess != null && paymentSuccess.Value)
            {
                ViewBag.Message = "Payment successful. You are now a Premium Tier user.";
            }

            var user = userRepo.GetCurrentUser(User);

            ViewBag.IsRegistered = user != null;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(SendEmailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("rhoda.damore@ethereal.email");

                //To Email Address - your need to enter your to email address
                mail.To.Add("rhoda.damore@ethereal.email");

                mail.Subject = sendMailDto.Subject;

                //you can specify also CC and BCC - i will skip this
                //mail.CC.Add("");
                //mail.Bcc.Add("");

                mail.IsBodyHtml = true;

                string content = "Name : " + sendMailDto.Name;
                content += "<br/> Message : " + sendMailDto.Message;

                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.ethereal.email");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("rhoda.damore@ethereal.email", "Wd41Ar9hyKgFuU4r8V");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; // this is default port number - you can also change this
                smtpClient.EnableSsl = true; // if ssl required you need to enable it
                smtpClient.Send(mail);

                ViewBag.Message = "Message sent successfully";

                // now i need to create the from 
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //If any error occured it will show
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
        public ActionResult UserFirstView()
        {
            ViewBag.Message = "UserFirstView";

            return View();
        }

       

       
    }
}
