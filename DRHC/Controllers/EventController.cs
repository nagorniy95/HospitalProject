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
    public class EventController : Controller
    {
        private readonly DrhcCMSContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public object FlashMessage { get; private set; }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public EventController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
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

        [HttpPost]
        public ActionResult Create(string img_New, string title_New, string desc_New, string date_New)
        {
            string query = "INSERT into Events (EventImage, EventTitle, EventDescription, EventDate) VALUES (@img, @title, @desc, @date)";

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@img", img_New);
            param[1] = new SqlParameter("@title", title_New);
            param[2] = new SqlParameter("@desc", desc_New);
            param[3] = new SqlParameter("@date", date_New);

            db.Database.ExecuteSqlCommand(query, param);

            TempData["result"] = "The event has been added successfully.";

            return RedirectToAction("Add");

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }

            Event events = db.Event.Find(id);

            return View(events);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, string img, string title, string desc, string date)
        {

            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }


            if ((id == null) || (db.Event.Find(id) == null))
            {
                return NotFound();
            }

            string query = "UPDATE Events SET EventImage=@img, EventTitle=@title, EventDescription=@desc, EventDate=@date WHERE EventID=@id";

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@img", img);
            param[1] = new SqlParameter("@title", title);
            param[2] = new SqlParameter("@desc", desc);
            param[3] = new SqlParameter("@date", date);
            param[4] = new SqlParameter("@id", id);


            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }

            if ((id == null) || (db.Event.Find(id) == null))
            {
                return NotFound();
            }

            string query = "DELETE from Events WHERE EventID=@id";
            SqlParameter param = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {

            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }

            return View(db.Event.ToList());
        }
    }
}