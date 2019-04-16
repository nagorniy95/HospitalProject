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

namespace DRHC.Controllers
{
    public class SearchCategoryController : Controller
    {
        private readonly DrhcCMSContext db;
        //This function will return the current user at some point when called

        //We need the usermanager class to get things like the id or name
        //Right now we only have one user type (ApplicationUser) but we could have others.
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public SearchCategoryController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //================================================================================= Read

        public async Task<ActionResult> List()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                ViewData["UserInfo"] = user.Id;
            }

            string query = "select * from SearchCategory";
            
            IEnumerable<SearchCategory> searchCategories;
            searchCategories = db.searchCategory.FromSql(query);

            return View(searchCategories);
        }
        //================================================================================= Create

        public ActionResult New()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string SearchCategoryTitle, string SearchCategoryDescriptioin)
        {
            string query = "insert into SearchCategory (SearchCategoryTitle, SearchCategoryDescriptioin)" +
                " values (@title, @description)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@title", SearchCategoryTitle);
            myparams[1] = new SqlParameter("@description", SearchCategoryDescriptioin);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.searchCategory.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from SearchCategory where SearchCategoryID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            SearchCategory mytag = db.searchCategory.FromSql(query, param).FirstOrDefault();
            return View(mytag);
        }


        [HttpPost]
        public ActionResult Edit(int? id, string SearchCategoryTitle, string SearchCategoryDescription)
        {
            if ((id == null) || (db.searchCategory.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update SearchCategory set SearchCategoryTitle=@title,SearchCategoryDescription=@desc" +
                " where SearchCategoryID=@id";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@title", SearchCategoryTitle);
            myparams[1] = new SqlParameter("@desc", SearchCategoryDescription);
            myparams[2] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Delete


        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.searchCategory.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from SearchCategory where SearchCategoryID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");

        }

    } // end class

}