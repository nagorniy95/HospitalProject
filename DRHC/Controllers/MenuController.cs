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
    public class MenuController : Controller
    {
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public MenuController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
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
        public ActionResult Create(string ItemName, string Type, string Price)
        {
            string query = "insert into Menus (ItemName,Type,Price) " +
                "values (@ItemName,@Type,@Price)";

            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@ItemName", ItemName);
            myparams[1] = new SqlParameter("@Type", Type);
            myparams[2] = new SqlParameter("@Price", Price);
            db.Database.ExecuteSqlCommand(query, myparams);
            return RedirectToAction("List", "Order");
        }
    }
}