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
    public class ContactFormController : Controller

    {
        private readonly DrhcCMSContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public object FlashMessage { get; private set; }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public ContactFormController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
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
        public ActionResult Create(string name_New, string email_New, string phone_New, string message_New)
        {
            string query = "INSERT into ContactForms (Name, Email, Phone, Message) VALUES (@name, @email, @phone, @message)";

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@name", name_New);
            param[1] = new SqlParameter("@email", email_New);
            param[2] = new SqlParameter("@phone", phone_New);
            param[3] = new SqlParameter("@message", message_New);

            db.Database.ExecuteSqlCommand(query, param);

            TempData["result"] = "The form has been submitted successfully and a representative will get in touch with you.";

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


            ContactForm contactForm = db.ContactForm.Find(id);

            return View(contactForm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, string name, string email, string phone, string message)
        {

            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }


            if ((id == null) || (db.ContactForm.Find(id) == null))
            {
                return NotFound();
            }

            string query = "UPDATE ContactForms SET Name=@name, Email=@email, Phone=@phone, Message=@message WHERE ContactID=@id";

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@name", name);
            param[1] = new SqlParameter("@email", email);
            param[2] = new SqlParameter("@phone", phone);
            param[3] = new SqlParameter("@message", message);
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

            if ((id == null) || (db.ContactForm.Find(id) == null))
            {
                return NotFound();
            }

            string query = "DELETE from ContactForms WHERE ContactID=@id";
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

            return View(db.ContactForm.ToList());
        }
    }
}