using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace DRHC.Controllers
{
    public class FaqController : Controller
    {

        private readonly DrhcCMSContext db;
        private readonly IHostingEnvironment _env;

        //constructor function which takes a DrhcCMSContext as a constructor.
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public FaqController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
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
        public ActionResult Create(string Questions_New, string Answers_New)
        { 

            //Raw Query   
            string query = "insert into Faqs (Questions, Answers) values (@Questions, @Answers)";

            //SQL parameterized query technique
            //[SqlParameter[] myparams] => SET variable myparams as an array of type (SqlParameter)
            //[new SqlParameter[1]] => Create a new SqlParameter array with 3 items
            SqlParameter[] myparams = new SqlParameter[2];
            //@title paramter
            myparams[0] = new SqlParameter("@Questions", Questions_New);
            //@bio parameter
            myparams[1] = new SqlParameter("@Answers", Answers_New);
            

            //Run the parameterized query (DML - Data Manipulation Language)
            //Insert into blogs ( .. ) values ( .. ) 
            db.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
            //GOTO: 
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Faqs.ToList());
        }


        /* public IActionResult Index()
         {
             return View();
         }*/
    }
}