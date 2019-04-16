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
    public class TestimonialController : Controller
    {

       
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public TestimonialController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
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

            
            return View(db.TestimonialStatuss.ToList());
        }
   
        [HttpPost]
        public ActionResult Create(string UserFName, string UserLName, string Title, string Story, int? TestimonialStatusID)
        {   
            string query = "insert into Testimonials (UserFName, UserLName, Title,Story,TestimonialStatusID) " +
                "values (@UserFName, @UserLName, @Title,@Story,@TestimonialStatusID)";

           // var TestimonialStatusID = await db.Blogs.Where(b => b.AuthorID == uauthorid);

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@UserFName", UserFName);
            myparams[1] = new SqlParameter("@UserLName", UserLName);
            myparams[2] = new SqlParameter("@Title", Title);
            myparams[3] = new SqlParameter("@Story", Story);
            myparams[4] = new SqlParameter("@TestimonialStatusID", TestimonialStatusID);

            db.Database.ExecuteSqlCommand(query, myparams);
  
            return RedirectToAction("List");
        }


        public async Task<ActionResult> List(int pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

           if (userstate==0){
                return RedirectToAction("Register", "Account");}

            /*Pagination Algorithm*/
            var testimonials = await db.Testimonials.Include(t => t.TestimonialStatus).ToListAsync();
            int count = testimonials.Count();
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

            List<Testimonial> testi = await db.Testimonials.Include(t => t.TestimonialStatus).Skip(start).Take(perpage).ToListAsync();
            /*End of Pagination  Algorithm*/

            return View(testi);

        }



        //This shows the edit interface
        //The edit interface is more advanced with a relational record now.
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }


           
            TestimonialEdit te = new TestimonialEdit();
            
            te.Testimonial =
                db.Testimonials
                    .Include(t => t.TestimonialStatus)
                    .SingleOrDefault(t => t.TestimonialID == id);
            //get blogs that belong to this user
            te.TestimonialStatuss = db.TestimonialStatuss.ToList();
           
            //if we have info, pass it to Page/View.cshtml
            if (te.Testimonial != null) return View(te);
            else return NotFound();
        }

        //This one actually does the editing commmand
        [HttpPost]
        public async Task<ActionResult> Edit(int id, int? TestimonialStatusID)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }
            //[(id == null) ]=>no ID in GET
            //[(db.Pages.Find(id) == null)]=>couldn't find this page
            if (db.Testimonials.Find(id) == null)
            {
                //Show error message
                return NotFound();

            }
            //Raw query data
            string query = "update Testimonials set TestimonialStatusID = @TestimonialStatusID " +
                "where TestimonialID = @id";



            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@TestimonialStatusID", TestimonialStatusID);
            myparams[1] = new SqlParameter("@id", id);
            
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: SHOW method in PageController.cs and pass argument (page)id
            return RedirectToAction("List");

            //return RedirectToAction("Show/" + id);
        }


        //GET of localhost/pages/delete/2 implies
        //delete action on pages controller with id 2
        public ActionResult Delete(int id)
        {
            string query = "delete from Testimonials where TestimonialID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));

           
            //GOTO: method List in PageController.cs
            return RedirectToAction("List");
        }




    }
}