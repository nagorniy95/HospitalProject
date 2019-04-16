using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using DRHC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class TipAndLetterController : Controller
    {
        //makes a BlogCMSContext
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private async Task<Models.ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public TipAndLetterController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
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

        public async Task<ActionResult> New()
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }


            TipAndLetterEdit tagandstatus = new TipAndLetterEdit();
            tagandstatus.Tags = db.Tags.ToList();
            tagandstatus.TipStatuss = db.TipStatuss.ToList();

            return View(tagandstatus);
        }


        [HttpPost]
        public ActionResult Create(string Title, string Message, int? TagID, int? TipStatusID)
        {
            string query = "insert into TipAndLetters (Title, Message, TagID,TipStatusID) " +
                "values (@Title, @Message, @TagID,@TipStatusID)";

            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@Message", Message);
            myparams[2] = new SqlParameter("@TagID", TagID);
            myparams[3] = new SqlParameter("@TipStatusID", TipStatusID);

            db.Database.ExecuteSqlCommand(query, myparams);
            return RedirectToAction("List");
        }


        public async Task<IActionResult> List(int pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }



            /*Pagination Algorithm*/
            var htl = await db.TipAndLetters.Include(t => t.TipStatus).Include(t => t.Tag).ToListAsync();
            int count = htl.Count();
            int perpage = 3;
            int maxpage = (int)Math.Ceiling((decimal)count / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = perpage * pagenum;
            ViewData["pagenum"] = (int)pagenum;
            ViewData["PaginationSummary"] = "";
            if (maxpage > 0)
            {
                ViewData["PaginationSummary"] =
                    (pagenum + 1).ToString() + " of " +
                    (maxpage + 1).ToString();
            }

            List<TipAndLetter> HTL = await db.TipAndLetters.Include(t => t.TipStatus).Include(t => t.Tag).Skip(start).Take(perpage).ToListAsync();

            return View(HTL);
        }


        
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }



            TipAndLetterEdit htl = new TipAndLetterEdit();

            htl.TipAndLetter =
                db.TipAndLetters
                    .Include(t => t.TipStatus)
                    .Include(t => t.Tag)
                    .SingleOrDefault(t => t.TipAndLetterID == id);

            htl.TipStatuss = db.TipStatuss.ToList();
            htl.Tags = db.Tags.ToList();

            if (htl.TipAndLetter != null) return View(htl);
            else return NotFound();
        }

        //This one actually does the editing commmand
        [HttpPost]
        public async Task<ActionResult> Edit(int id, string Title, string Message, int? TagID, int? TipStatusID)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }
            if (db.TipAndLetters.Find(id) == null)
            {
                //Show error message
                return NotFound();

            }
            //Raw query data
            string query = "update TipAndLetters set Title = @Title, Message = @Message,TipStatusID = @TipStatusID ,TagID = @TagID" +
                " where TipAndLetterID = @id";



            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@Message", Message);
            myparams[2] = new SqlParameter("@TagID", TagID);
            myparams[3] = new SqlParameter("@TipStatusID", TipStatusID);
            myparams[4] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");

            //return RedirectToAction("Show/" + id);
        }


        
        public ActionResult Delete(int id)
        {
            string query = "delete from TipAndLetters where TipAndLetterID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            //GOTO: method List in PageController.cs
            return RedirectToAction("List");
        }








    }
}