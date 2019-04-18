using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class EcardController : Controller
    {

        private readonly DrhcCMSContext db;
        private readonly IHostingEnvironment _env;

        //constructor function which takes a DrhcCMSContext as a constructor.
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public EcardController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
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
        public ActionResult Create(string PatientName_New, string Department_New, int RoomNo_New, string SenderName_new, string SenderEmail_New, string Message_New)
        {

            //Raw Query   
            string query = "insert into Ecards (PatientName, Department, RoomNo, SenderName, SenderEmail, Message) values (@PatientName, @Department,@RoomNo,@SenderName,@SenderEmail,@Message)";

            SqlParameter[] myparams = new SqlParameter[6];

            myparams[0] = new SqlParameter("@PatientName", PatientName_New);
            myparams[1] = new SqlParameter("@Department", Department_New);
            myparams[2] = new SqlParameter("@RoomNo", RoomNo_New);
            myparams[3] = new SqlParameter("@SenderName", SenderName_new);
            myparams[4] = new SqlParameter("@SenderEmail", SenderEmail_New);
            myparams[5] = new SqlParameter("@Message", Message_New);

            
            db.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.Ecards.ToList());
        }


    }
}