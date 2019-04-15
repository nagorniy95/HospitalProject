﻿using System;
using System.Diagnostics;
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
    public class RecRoomBookingController : Controller
    {
        
        private readonly DrhcCMSContext db;

        public RecRoomBookingController(DrhcCMSContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            return RedirectToAction("Admin/List");
        }       

        public ActionResult List()
        {
            List<RecRoomBooking> recroombookings = db.RecRoomBooking.ToList();

            return View("List");//make views
        }
        
        
        [HttpPost]
        public ActionResult Create(string Fname_New, string Lname_New, string Time_New, string Day_New, string Month_New, string Email_New, string Phone_New)
        {

            /*Debug.WriteLine(Fname_New, Lname_New, Time_New, Day_New, Month_New,Email_New,  Phone_New);*/

            string query = "insert into RecRoombooking (Fname, Lname, Day, Week, Month, Email, Phone) values (@fname, @lname, @day, @week, @month, @email, @phone)";

            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@fname", Fname_New);
            myparams[1] = new SqlParameter("@lname", Lname_New);
            myparams[2] = new SqlParameter("@day", Day_New);
            myparams[3] = new SqlParameter("@month", Month_New);
            myparams[4] = new SqlParameter("@email", Email_New);
            myparams[5] = new SqlParameter("@phone", Phone_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            //Debug.WriteLine(myparams);

            return RedirectToAction("Admin/List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RecRoomBooking recRoomBooking = db.RecRoomBooking.Find(id);

            return View(recRoomBooking);
        }

        [HttpPost]
        public ActionResult Edit(int id, string Fname, string Lname, string Day, string Week, string Month, string Email, string Phone)
        {
            if ((id == null) || (db.RecRoomBooking.Find(id) == null))
            {
                return NotFound();

            }

            string query = "update RecRoomBookings set Fname=@fname, Lname=@lname, Day=@day, Week=@week, Month=@month, Email=@email, Phone=@phone";

            SqlParameter[] myparams = new SqlParameter[8];
            myparams[0] = new SqlParameter("@fname", Fname);
            myparams[1] = new SqlParameter("@lname", Lname);
            myparams[2] = new SqlParameter("@day", Day);
            myparams[3] = new SqlParameter("@week", Week);
            myparams[4] = new SqlParameter("@month", Month);
            myparams[5] = new SqlParameter("@email", Email);
            myparams[6] = new SqlParameter("@phone", Phone);
            myparams[7] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);//do I want show or list?
        }
        public ActionResult Show(int? id)
        {
            return View();
        }
        
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.RecRoomBooking.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from RecRoomBookings where BookingID=@id";
            SqlParameter myparam = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, myparam);

            return RedirectToAction("List");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

    /*
        public IActionResult Index()
        {
            return View();
        }

    */

}