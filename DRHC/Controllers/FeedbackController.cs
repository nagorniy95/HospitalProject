using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DRHC.Models;
using DRHC.Data;

namespace DRHC.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly DrhcCMSContext db;
        //This function will return the current user at some point when called

        //We need the usermanager class to get things like the id or name
        //Right now we only have one user type (ApplicationUser) but we could have others.
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public FeedbackController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }

        // Redirect to the Feedback List
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //================================================================================= Read

        public async Task<ActionResult> List()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                ViewData["UserInfo"] = user.Id;
            }

            string query = "select * from Feedback";
  
            IEnumerable<Feedback> feedbacks;
            
            feedbacks = db.feedback.FromSql(query);
            return View(feedbacks);
        }
        //================================================================================= Create

        public ActionResult New()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string AuthorFName, string AuthorLName, string AuthorEmail, string AuthorPhone, string AuthorMessage)
        {
            string query = "insert into Feedback (AuthorFName, AuthorLName, AuthorEmail, AuthorPhone, AuthorMessage)" +
                " values (@fname, @lname, @email, @phone, @message)";
            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@fname", AuthorFName);
            myparams[1] = new SqlParameter("@lname", AuthorLName);
            myparams[2] = new SqlParameter("@email", AuthorEmail);
            myparams[3] = new SqlParameter("@phone", AuthorPhone);
            myparams[4] = new SqlParameter("@message", AuthorMessage);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {

            if ((id == null) || (db.feedback.Find(id) == null))
            {
                return NotFound();
            }


            string query = "select * from Feedback where FeedbackID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Feedback mytag = db.feedback.FromSql(query, param).FirstOrDefault();
            return View(mytag);
        }


        [HttpPost]
        public ActionResult Edit(int? id, string AuthorFName, string AuthorLName, string AuthorEmail, string AuthorPhone, string AuthorMessage)
        {


            if ((id == null) || (db.feedback.Find(id) == null))
            {
                return NotFound();
            }

            string query = "update Feedback set AuthorFName=@fname, AuthorLName=@lname, AuthorEmail = @email, AuthorPhone = @phone, AuthorMessage = @message" +
                " where FeedbackID=@id";
            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@fname", AuthorFName);
            myparams[1] = new SqlParameter("@lname", AuthorLName);
            myparams[2] = new SqlParameter("@email", AuthorEmail);
            myparams[3] = new SqlParameter("@phone", AuthorPhone);
            myparams[4] = new SqlParameter("@message", AuthorMessage);
            myparams[5] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Delete

        public ActionResult Delete(int? id)
        {

            if ((id == null) || (db.feedback.Find(id) == null))
            {
                return NotFound();

            }

            string query = "delete from Feedback where FeedbackID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");

        }


    } // end class
}