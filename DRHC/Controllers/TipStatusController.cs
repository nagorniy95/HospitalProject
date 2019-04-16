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
    public class TipStatusController : Controller
    {
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public TipStatusController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }

        public ActionResult New()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create(string TipStatusName)
        {
          
            string query = "insert into TipStatuss (TipStatusName) values (@TipStatusName)";

            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@TipStatusName", TipStatusName);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }











        public IActionResult List()
        {
            return View(db.TipStatuss.ToList());
        }

    }
}