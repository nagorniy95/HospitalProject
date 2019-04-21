using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using DRHC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
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
            if (user.AdminID != null) return 2; //User is not admin author

            else return -1;
        }

        public async Task<ActionResult> New()
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {


                TipAndLetterEdit tagandstatus = new TipAndLetterEdit();
                tagandstatus.Tags = db.Tags.ToList();
                var tags = tagandstatus.Tags.Count();
                tagandstatus.TipStatuss = db.TipStatuss.ToList();
                var tipstatus = tagandstatus.TipStatuss.Count();
                if (tags == 0) return RedirectToAction("New", "Tag");
                else if (tipstatus == 0) return RedirectToAction("New", "TipStatus");
                else return View(tagandstatus);
            }
            else return RedirectToAction("index", "Home");

        }


        [HttpPost]
        public async Task<ActionResult> Create(string Title, string Message, int? TagID, int? TipStatusID)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {
                DateTime d =  DateTime.Now;
                
                string query = "insert into TipAndLetters (Title, Message,DateCreated, TagID,TipStatusID) " +
                "values (@Title, @Message,@DateCreated, @TagID,@TipStatusID)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@Message", Message);
            myparams[2] = new SqlParameter("@TagID", TagID);
            myparams[3] = new SqlParameter("@TipStatusID", TipStatusID);
                myparams[4] = new SqlParameter("@DateCreated", d);

                db.Database.ExecuteSqlCommand(query, myparams);
            TipStatus ts = db.TipStatuss.Find(TipStatusID);
            if (ts.TipStatusName.Equals("Publish"))
            {
                List<TipAndLetter> tl = db.TipAndLetters.ToList();
                int id = (int)tl.Max(tipandlet => tipandlet.TipAndLetterID);
                return RedirectToAction("Sendletter/" + id);

            }


            return RedirectToAction("List");
        }
            else return RedirectToAction("index", "Home");

        }


        public async Task<IActionResult> List(int pagenum)
        {

            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {
                
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
            else return RedirectToAction("index", "Home");

        }
        public async Task<ActionResult> Show(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {
            var htl = db.TipAndLetters.Include(t => t.TipStatus).Include(t => t.Tag).SingleOrDefault(t => t.TipAndLetterID == id);

            return View(htl);
            }
            else return View("Index", "Home");



        }


        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {
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
            else return RedirectToAction("index", "Home");

        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, string Title, string Message, int? TagID, int? TipStatusID)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {
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
            TipStatus ts = db.TipStatuss.Find(TipStatusID);
            if (ts.TipStatusName.Equals("Publish"))
            {

                return RedirectToAction("Sendletter/" + id);

            }


            return RedirectToAction("List");

                //return RedirectToAction("Show/" + id);
            }
            else return RedirectToAction("index", "Home");

        }



        public async Task<ActionResult> Delete(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {

                string query = "delete from TipAndLetters where TipAndLetterID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            return RedirectToAction("List");
        }
            else return RedirectToAction("index", "Home");

        }




        public async Task<ActionResult> SendLetterAsync(int id)
        {
            var _user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(_user);
            if (userstate == 2)
            {

                List<Registration> r = db.Registrations.ToList();
             if (r.Count() == 0)
                { return View("List"); } 
            TipAndLetter t = db.TipAndLetters.Include(tl => tl.TipStatus).Include(tl => tl.Tag).SingleOrDefault(tl => tl.TipAndLetterID == id);
            string title = t.Title;
            string Message = t.Message;
            string status = t.TipStatus.TipStatusName;
            string subject = t.Tag.TagName+" From DRHC Hospital";
            string mailmessage = "<h2 class='text-center'><strong>" + title + "</strong></h2>";
            mailmessage +="<p>"+ Message + "</p>";
            foreach (var user in r)
            {
                string email = user.UserEmail;
                string username = user.UserFName + " " + user.UserLName;

                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("admin", "wdn01269796@gmail.com"));
                msg.To.Add(new MailboxAddress(username, email));
                msg.Subject = subject;
                msg.Body = new TextPart("html")
                {
                    Text = mailmessage
                };


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("wdn01269796@gmail.com", "mailtest1234");
                    client.Send(msg);
                    client.Disconnect(true);



                }

            }
                return RedirectToAction("List");

            }
            else return RedirectToAction("index", "Home");


        }








    }
}