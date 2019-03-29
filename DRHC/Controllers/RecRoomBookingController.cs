using System;
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
        /*
        private readonly DrhcCMSContext db;

        public RecRoomBookingController(DrhcCMSContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<RecRoomBooking> recroombookings = db.RecRoomBookings.ToList();

            return View();//make views
        }
        //CMSContext does not contain a definition for RecRoomBooking, probably the others too, find out how to do that

        /*public ActionResult New()
        {
            //ViewModel? Do I need this ActionResult if there's no relationship for the rec room booking
        }*/
        /*
        [HttpPost]
        public ActionResult Create(string Fname_New, string Lname_New, DateTime Checkedtime_New, string Email_New, string Phone_New)
        {
            string query = "insert into RecRoombooking (Fname, Lname, Checkedtime, Email, Phone) values (@fname, @lname, @checkedtime, @email, @phone)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@fname", Fname_New);
            myparams[1] = new SqlParameter("@lname", Lname_New);
            myparams[2] = new SqlParameter("@checkedtime", Checkedtime_New);
            myparams[3] = new SqlParameter("@email", Email_New);
            myparams[4] = new SqlParameter("@phone", Phone_New);
            db.Database.ExecuteSqlCommand(query, myparams);

            Debug.WriteLine(myparams);

            return RedirectToAction("List");
        }








        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}