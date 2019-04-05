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
    /*
    public class PatientDietController : Controller
    {
        private readonly DrhcCMSContext db;

        public PatientDietController(DrhcCMSContext context)
        {
            db = context;
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Index()
        {
            return RedirectToAction("");//which list, do this twice?
        }
        public ActionResult List()
        {
            List<Patient> patients = db.Patients.ToList();

            return View(patients);
        }
        public ActionResult New()
        {
            //Check if viewmodel is correct
        }
        [HttpPost]
        public ActionResult Create(string Fname_New, string Lname_New, DateTime DateAdmitted_New, string RoomNumber_New, int DietaryRestrictionsID_New)// Foreign Key here?
        {
            string query = "insert into Patients (Fname, Lname, DateAdmitted, RoomNumber, DietaryRestrictionsID ) values (@fname, @lname, @date, @roomnumber, @dietrestrict";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@fname", Fname_New);
            myparams[1] = new SqlParameter("@lname", Lname_New);
            myparams[2] = new SqlParameter("@date", DateAdmitted_New);
            myparams[3] = new SqlParameter("@roomnumber", RoomNumber_New);
            myparams[4] = new SqlParameter("@dietrestrict", DietaryRestrictionsID_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            
            return RedirectToAction("");//put list name
        }
        public ActionResult Edit(int id)
        {

        }
    }
    */
}