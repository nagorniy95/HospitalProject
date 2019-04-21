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

        private readonly UserManager<ApplicationUser> _userManager;

        public object FlashMessage { get; private set; }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public EcardController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
        {

            db = context;
            _userManager = usermanager;
        }


        public async Task<int> GetUserDetails(ApplicationUser user)
        {
            if (user == null) return 0;

            if (user.AdminID == null) return 1; //User is not admin 
            else return 2;

            return -1;
        }


        public ActionResult Add()
        {
            return View();
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


        public ActionResult Delete(int? id)
        {
            /*
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }

            if ((id == null) || (db.Faqs.Find(id) == null))
            {
                return NotFound();
            }*/

            string query = "DELETE from Ecards WHERE EcardID=@id";
            SqlParameter param = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }




























        /*

         public async Task<ActionResult> Delete(int? id)
         {
             var user = await GetCurrentUserAsync();
             var userstate = await GetUserDetails(user);

             if (userstate == 0)
             {
                 return RedirectToAction("Register", "Account");
             }

             if ((id == null) || (db.Ecards.Find(id) == null))
             {
                 return NotFound();
             }

             string query = "DELETE from Ecard WHERE EcardID=@id";
             SqlParameter param = new SqlParameter("@id", id);

             db.Database.ExecuteSqlCommand(query, param);

             return RedirectToAction("List");
         }

         /* public async Task<ActionResult> List()
          {

              var user = await GetCurrentUserAsync();
              var userstate = await GetUserDetails(user);

              if (userstate == 0)
              {
                  return RedirectToAction("Register", "Account");
              }

              return View(db.ecards.ToList());
          }*/
    }



}
