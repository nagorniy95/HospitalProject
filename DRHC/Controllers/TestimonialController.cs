using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class TestimonialController : Controller
    {

       
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public TestimonialController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }


        public async Task<int> GetUserDetails(ApplicationUser user)
        {
            //check if the user is an author or not.
            //UserState
            //0 => No User
            //1 => has user has no author not admin
            //2 => has user has author but no blogs no testimonial
            //3 => has user has author and at least 1 testimonial
            if (user == null) return 0;
          
            if (user.AdminID == null) return 1; //User is not admin author
            else return 2;
            
            return -1;//something went wrong
        }




        public ActionResult New()
        {

            
            return View(db.TestimonialStatuss.ToList());
        }
   
        [HttpPost]
        public ActionResult Create(string UserFName, string UserLName, string Title, string Story, int? TestimonialStatusID)
        {   
            string query = "insert into Testimonials (UserFName, UserLName, Title,Story,TestimonialStatusID) " +
                "values (@UserFName, @UserLName, @Title,@Story,@TestimonialStatusID)";

           // var TestimonialStatusID = await db.Blogs.Where(b => b.AuthorID == uauthorid);

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@UserFName", UserFName);
            myparams[1] = new SqlParameter("@UserLName", UserLName);
            myparams[2] = new SqlParameter("@Title", Title);
            myparams[3] = new SqlParameter("@Story", Story);
            myparams[4] = new SqlParameter("@TestimonialStatusID", TestimonialStatusID);

            db.Database.ExecuteSqlCommand(query, myparams);
  
            return RedirectToAction("List");
        }


        public async Task<ActionResult> List()
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            ViewData["UserState"] = userstate;

           if (userstate==0){
                return RedirectToAction("Register", "Account");}

            return View(db.Testimonials.ToList());



        }

    }
}