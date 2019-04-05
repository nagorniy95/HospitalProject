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
            List<VolunteerApplicant> volunteerapplicants = db.VolunteerApplicant.ToList();

            return View();//make views
        }
        //CMSContext does not contain a definition for VolunteerApplicants

        /*public ActionResult New()
        {
            //ViewModel
        }*/
      /*
     [HttpPost]
     public ActionResult Create(string Fname_New, string Lname_New, string Address_New, string City_New, string Postal_New,  string Province_New, string Phone_New, string Email_New, string Experience_New, DateTime ApplicationDate_New, Boolean Approval_New)
     {
         string query = "insert into VolunteerApplicant (Fname, Lname, Address, City, Postal, Province, Phone, Email, Experience, ApplicationDate, Approval) values (@fname, @lname, @address, @city, @postal, @province, @phone, @email, @experience, @applicationdate, @approval )"; 

         SqlParameter[] myparams = new SqlParameter[11];
         myparams[0] = new SqlParameter("@fname", Fname_New);    
         myparams[1] = new SqlParameter("@lname", Lname_New);
         myparams[2] = new SqlParameter("@address", Address_New);
         myparams[3] = new SqlParameter("@city", City_New);
         myparams[4] = new SqlParameter("@postal", Postal_New);
         myparams[5] = new SqlParameter("@province", Province_New);
         myparams[6] = new SqlParameter("@phone", Phone_New);
         myparams[7] = new SqlParameter("@email", Email_New);
         myparams[8] = new SqlParameter("@experience", Experience_New);
         myparams[9] = new SqlParameter("@applicationdate", ApplicationDate_New);
         myparams[10] = new SqlParameter("@approval", Approval_New);


         db.Database.ExecuteSqlCommand(query, myparams);

         return RedirectToAction("List");
     }

        public ActionResult Edit(int id)
        {
            //Make ViewModel
        }
        [HttpPost]
        public ActionResult Edit(int id, string Fname, string Lname, string Address, string City, string Postal, string Province, string Phone, string Email, string Experience, DateTime ApplicationDate, Boolean Approval)
        {
            if ((id == null) || (db.VolunteerApplicants.Find(id) == null))
            //the bit following db is from DBcontext file
            {
                return NotFound();
            }

            //the bit following query = "update is also from DBcontext file
            string query = "update VolunteerApplicants set Fname=@fname, Lname=@lname, Address=@address, City=@city, Postal=@postal, Province=@province, Phone=@phone, Email=@email, Experience= @experience, ApplicationDate=@applicationdate, Approval=@approval";

            SqlParameter[] myparams = new SqlParameter[11];
            myparams[0] = new SqlParameter("@fname", Fname);
            myparams[1] = new SqlParameter("@lname", Lname);
            myparams[2] = new SqlParameter("@address", Address);
            myparams[3] = new SqlParameter("@city", City);
            myparams[4] = new SqlParameter("@postal", Postal);
            myparams[5] = new SqlParameter("@province", Province);
            myparams[6] = new SqlParameter("@phone", Phone);
            myparams[7] = new SqlParameter("@email", Email);
            myparams[8] = new SqlParameter("@experience", Experience);
            myparams[9] = new SqlParameter("@applicationdate", ApplicationDate);
            myparams[10] = new SqlParameter("@approval", Approval );
            myparams[11] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("AdminApplicantList/"); //can this go here?
        }

        /*public ActionResult Show(int? id)
         {} Do I need a show? */
/*
        public ActionResult Delete(int? id)
        {
            if((id == null) || (db.VolunteerApplicants.Find(id) == null))
            {
                return NotFound();
            }
            string query = "delete from VolunteerApplicants where ApplicantID = @id";

            SqlParameter myparam = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparam);

            return RedirectToAction("AdminApplicantList");
        }

        //what does this do?
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}