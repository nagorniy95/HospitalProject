using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class TestimonialController : Controller
    {

        //makes a BlogCMSContext
        private readonly DrhcCMSContext db;
        //constructor function which takes a BlogCMSContext as a constructor.
        //Q: How does the Controller just *get* this context?
        //A: "magic" called dependency injection will put the data there.
        public TestimonialController(DrhcCMSContext context)
        {
            db = context;
        }

        public ActionResult New()
        {

            return View(db.TestimonialStatuss.ToList());
        }
        //Restricts this method to only handle POST
        //eg. POST to /Pages/Create/
        [HttpPost]
        public ActionResult Create(string UserFName, string UserLName, string Title, string Story, int? TestimonialStatusID)
        {
            string query = "insert into Testimonials (UserFName, UserLName, Title,Story,TestimonialStatusID) " +
                "values (@UserFName, @UserLName, @Title,@Story,@TestimonialStatusID)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@UserFName", UserFName);
            myparams[1] = new SqlParameter("@UserLName", UserLName);
            myparams[2] = new SqlParameter("@Title", Title);
            myparams[3] = new SqlParameter("@Story", Story);
            myparams[4] = new SqlParameter("@TestimonialStatusID", TestimonialStatusID);

            db.Database.ExecuteSqlCommand(query, myparams);
            //testing that the paramters do indeed pass to the method
            //Debug>Windows>Output
            Debug.WriteLine(query);
            return RedirectToAction("List");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Testimonials.ToList());
        }

    }
}