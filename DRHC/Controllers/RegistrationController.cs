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

namespace DRHC.Controllers
{
    public class RegistrationController : Controller
    {
      
        private readonly DrhcCMSContext db;
        private readonly IHostingEnvironment _env;
      
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

      

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
         
            string query = "insert into Faqs (UserFName, UserLName, UserEmail) values (@Fname, @lname, @Email)";

         
            SqlParameter[] myparams = new SqlParameter[3];
           
            myparams[0] = new SqlParameter("@Fname", Fname_New);

            myparams[1] = new SqlParameter("@lname", lname_New);
         
            myparams[2] = new SqlParameter("@Email", Email_New);

         
            db.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
         
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Registrations.ToList());
        }

      
    }
}