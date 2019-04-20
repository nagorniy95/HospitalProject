using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace DRHC.Controllers
{
    public class RegistrationController : Controller
    {
        //makes a BlogCMSContext
        private readonly DrhcCMSContext db;
        private readonly IHostingEnvironment _env;
        //constructor function which takes a DrhcCMSContext as a constructor.
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        //This function will return the current user at some point when called

        public RegistrationController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
        {

            db = context;
            _env = env;
            _userManager = usermanager;
        }



        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string Fname_New, string lname_New, string Email_New )
        {
            //Data Needed: None

            //Raw Query   
            string query = "insert into Registrations (UserFName, UserLName, UserEmail) values (@Fname, @lname, @Email)";

            //SQL parameterized query technique
            //[SqlParameter[] myparams] => SET variable myparams as an array of type (SqlParameter)
            //[new SqlParameter[1]] => Create a new SqlParameter array with 3 items
            SqlParameter[] myparams = new SqlParameter[3];
            //@title paramter
            myparams[0] = new SqlParameter("@Fname", Fname_New);
            //@bio parameter
            myparams[1] = new SqlParameter("@lname", lname_New);
            //@author (id) FOREIGN KEY paramter
            myparams[2] = new SqlParameter("@Email", Email_New);
            
            db.Database.ExecuteSqlCommand(query, myparams);
            List<Registration> r = db.Registrations.ToList();
            int id = (int)r.Max(user => user.UserID);
            return RedirectToAction("Sendletter/" + id);
            
        }

        public ActionResult List()
        {
            return View(db.Registrations.ToList());
        }

        public ActionResult SendLetter(int id)
        {
            Registration r = db.Registrations.SingleOrDefault(u => u.UserID == id);
           List<TipAndLetter> tl = db.TipAndLetters.Include(htl => htl.TipStatus).Include(htl => htl.Tag).ToList();

            string email = r.UserEmail;
            string username = r.UserFName + " " + r.UserLName;
            foreach (var t in tl)
            {

                string title = t.Title;
                string Message = t.Message;
                string type = t.TipStatus.TipStatusName;
                string mailmessage = "<h2 class='text-center'><strong>" + title + "</strong></h2>";
                
                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("admin", "wdn01269796@gmail.com"));
                msg.To.Add(new MailboxAddress("username", email));
                msg.Subject = type;
                msg.Body = new TextPart("html")
                {
                    Text = mailmessage
                };


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("wdn01269796@gmail.com", "mailtest1234");
                    client.Send(msg);
                    client.Disconnect(true);



                }

            }
            return RedirectToAction("List");

        }

    }
}