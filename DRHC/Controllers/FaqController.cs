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

            SqlParameter[] myparams = new SqlParameter[2];
           
            myparams[0] = new SqlParameter("@Questions", Questions_New);
        
            myparams[1] = new SqlParameter("@Answers", Answers_New);
            
            db.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
          
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Faqs.ToList());
        }

    }
}