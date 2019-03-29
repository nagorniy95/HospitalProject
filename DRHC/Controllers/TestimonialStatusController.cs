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

namespace DRHC.Controllers
{
    public class TestimonialStatusController : Controller
    {

        //makes a BlogCMSContext
        private readonly DrhcCMSContext db;
        //constructor function which takes a BlogCMSContext as a constructor.
        //Q: How does the Controller just *get* this context?
        //A: "magic" called dependency injection will put the data there.

        //We need the usermanager class to get things like the id or name
        //Right now we only have one user type (ApplicationUser) but we could have others.
        private readonly UserManager<ApplicationUser> _userManager;
        //This function will return the current user at some point when called
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public TestimonialStatusController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }

        public ActionResult New()
        {
        

            //GOTO Views/Blog/New.cshtml
            return View();
        }

        [HttpPost]
        public ActionResult Create(string TestimonialStatusName)
        {
            //Data Needed: None

            //Raw Query   
            string query = "insert into TestimonialStatuss (TestimonialStatusName) values (@TestimonialStatusName)";

            //SQL parameterized query technique
            //[SqlParameter[] myparams] => SET variable myparams as an array of type (SqlParameter)
            //[new SqlParameter[1]] => Create a new SqlParameter array with 3 items
            SqlParameter[] myparams = new SqlParameter[3];
            //@title paramter
            myparams[0] = new SqlParameter("@TestimonialStatusName", TestimonialStatusName);
       

            //Run the parameterized query (DML - Data Manipulation Language)
            //Insert into blogs ( .. ) values ( .. ) 
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }











        public IActionResult List()
        {
            return View(db.TestimonialStatuss.ToList());
        }
    }
}