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
    public class TagController : Controller
    {
   
        private readonly DrhcCMSContext db;
     
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public TagController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }

        public ActionResult New()
        {


            //GOTO Views/Tag/New.cshtml
            return View();
        }

        [HttpPost]
        public ActionResult Create(string TagName)
        {
           
            string query = "insert into Tags (TagName) values (@TagName)";

            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@TagName", TagName);

            db.Database.ExecuteSqlCommand(query, myparams);

       
            return RedirectToAction("List");
        }




        public IActionResult List()
        {
            return View(db.Tags.ToList());
        }
    }
}