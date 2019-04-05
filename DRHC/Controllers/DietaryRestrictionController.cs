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
    public class DietaryRestrictionController : Controller
    {
        /*
        private readonly DrhcCMSContext db;

        public DietaryRestrictionController(DrhcCMSContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("");  //which list goes here
        }
        public ActionResult List()
        {
            List<DietaryRestriction> restrictions = db.DietaryRestrictions.ToList();

            return View(restrictions);
        }

        public ActionResult New()
        {
            //double check viewmodels
        }

        [HttpPost]
        public ActionResult Create(string FoodType_New, string Fasting_New, DateTime FinishTime, string Preference_New, string Diabetic_New, string ClearLiquid_New, string LowFiber_New, string LowFat_New, string LowCholesterol_New, int PatientID_New)
        {
            string query = "insert into DietaryRestriction (FoodType, Fasting, FinishTime, Preference, Diabetic, ClearLiquid, LowFiber, LowFat, LowCholesterol, PatientID) values (@foodtype, @fasting, @finishtime, @preference, @diabetic, @clearliquid, @lowfiber, @lowfat, @lowcholesterol, @patient)";

            SqlParameter[] myparams = new SqlParameter[10];
            myparams[0] = new SqlParameter("@foodtype", FoodType_New);
            myparams[1] = new SqlParameter("@fasting", Fasting_New);
            myparams[2] = new SqlParameter("@finishtime", FinishTime);
            myparams[3] = new SqlParameter("@preference", Preference_New);
            myparams[4] = new SqlParameter("@diabetic", Diabetic_New);
            myparams[5] = new SqlParameter("@clearliquid", ClearLiquid_New);
            myparams[6] = new SqlParameter("@lowfiber", LowFiber_New);
            myparams[7] = new SqlParameter("@lowfat", LowFat_New);
            myparams[8] = new SqlParameter("@lowcholesterol", LowCholesterol_New);
            myparams[9] = new SqlParameter("@patient", PatientID_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

       
    




        
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}