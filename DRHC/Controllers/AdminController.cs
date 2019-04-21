using System;
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
using DRHC.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace DRHC.Controllers
{
    public class AdminController : Controller
    {

        private readonly DrhcCMSContext db;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public AdminController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
        {
            
            db = context;
            _env = env;
            _userManager = usermanager;
        }


        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
     
                if (user.AdminID == null) { ViewData["UserHasAdmin"] = "False"; }
                else { ViewData["UserHasAdmin"] = user.AdminID.ToString(); }
                return View(await db.admin.ToListAsync());
            }
            else
            {
                ViewData["UserHasAdmin"] = "None";
                return View(await db.admin.ToListAsync());
            }
        }

        public ActionResult New()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create()
        {

            Admin admin = new Admin();

            if (ModelState.IsValid)
            {
                db.admin.Add(admin);
                db.SaveChanges();
                var res = await MapUserToAdmin(admin);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }



        }

        private async Task<IActionResult> MapUserToAdmin(Admin a)
        {
            var user = await GetCurrentUserAsync();
            //mapping the user to the author
            user.admin = a;
            var user_res = await _userManager.UpdateAsync(user);
            if (user_res == IdentityResult.Success)
            {
                Debug.WriteLine("ok the amdin to the user.");
            }
            else
            {
                Debug.WriteLine("not ok the user is not  admin.");
                return BadRequest(user_res);
            }
            //mapping the author to the user
            a.user = user;
            a.UserID = user.Id;
            //checking that 
            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                var author_res = await db.SaveChangesAsync();
                if (author_res > 0) //some authors affected
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(author_res);
                }
            }
            else
            {
                return BadRequest("Unstable admin Model.");
            }

        }






        // For delete... in example make sure to change : var admin = db.Admins.FindAsync(id) ... ADD await before db....
        /* public IActionResult Index()
         {
             return View();
         }*/
    }
}