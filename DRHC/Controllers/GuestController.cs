using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class GuestController : Controller
    {

        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public GuestController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }


        public async Task<int> GetUserDetails(ApplicationUser user)
        {
            if (user == null) return 0;

            if (user.AdminID == null) return 1; //User is not admin author
            else return 2;

            return -1;//something went wrong
        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string NumberOfGuest)
        {
            string query = "insert into Guests (NumberOfGuest) " +
                "values (@NumberOfGuest)";

            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@NumberOfGuest", NumberOfGuest);
            db.Database.ExecuteSqlCommand(query, myparams);
            return RedirectToAction("New");
        }





    }
}