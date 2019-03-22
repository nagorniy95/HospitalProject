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



       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}