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
using DRHC.Models.ViewModels;
using DRHC.Data;

namespace DRHC.Controllers
{
    public class VolunteerApplicantController : Controller
    { /*
        private readonly DrhcCMSContext db;

        public VolunteerApplicantController(DrhcCMSContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<VolunteerApplicant> volunteerapplicants = db.VolunteerApplicants.ToList();

            return View();//make views
        }
        //CMSContext does not contain a definition for VolunteerApplicants

        /*public ActionResult New()
        {
            //ViewModel
        }*/
         /*
        [HttpPost]
        public ActionResult Create(string Fname_New, string Lname_New, string Address_New, string City_New, string Postal_New, string Phone_New, string Email_New, string Resume_New, string CoverLetter_New, DateTime ApplicationDate_New, Boolean Approval_New)
        {
            string query = "insert into RecRoombooking (Fname, Lname, Address, City, Postal, Phone, Email, Resume, CoverLetter, ApplicationDate, Approval) values (@fname, @lname, @address, @city, @postal, @phone, @email, @resume, @coverletter, @applicationdate, @approval )";

            SqlParameter[] myparams = new SqlParameter[11];
            myparams[0] = new SqlParameter("@fname", Fname_New);    
            myparams[1] = new SqlParameter("@lname", Lname_New);
            myparams[2] = new SqlParameter("@address", Address_New);
            myparams[3] = new SqlParameter("@city", City_New);
            myparams[4] = new SqlParameter("@postal", Postal_New);
            myparams[5] = new SqlParameter("@phone", Phone_New);
            myparams[6] = new SqlParameter("@email", Email_New);
            myparams[7] = new SqlParameter("@resume", Resume_New);
            myparams[8] = new SqlParameter("@coverletter", CoverLetter_New);
            myparams[9] = new SqlParameter("@@applicationdate", ApplicationDate_New);
            myparams[10] = new SqlParameter("@approval", Approval_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}