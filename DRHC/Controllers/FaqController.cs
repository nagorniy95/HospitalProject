using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace DRHC.Controllers
{
    public class FaqController : Controller
    {

        private readonly DrhcCMSContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public object FlashMessage { get; private set; }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        public FaqController(DrhcCMSContext context, IHostingEnvironment env, UserManager<ApplicationUser> usermanager)
        {

            db = context;
            _userManager = usermanager;
        }

        public async Task<int> GetUserDetails(ApplicationUser user)
        {
            if (user == null) return 0;

            if (user.AdminID == null) return 1; //User is not admin 
            if (user.AdminID != null) return 2; //User is not admin author

            else return -1;


        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult Show()
        {

            return View(db.Faqs);

        }


        public async Task<ActionResult> List(int pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 2)
            {

                var faqs = await db.Faqs.ToListAsync();
                int count = faqs.Count();
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

                List<Faq> faq = await db.Faqs.Skip(start).Take(perpage).ToListAsync();


                return View(faq);

            }



            else return RedirectToAction("index", "Home");


           /* string query = "select * from Faqs";

                IEnumerable<Faq> faqs = db.Faqs.FromSql(query);
            
                return View(faqs);*/
            
        }
       
        
        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string Questions_New, string Answers_New)
        {

            //Raw Query   
            string query = "insert into Faqs (Questions, Answers) values (@Questions, @Answers)";

            SqlParameter[] myparams = new SqlParameter[2];

            myparams[0] = new SqlParameter("@Questions", Questions_New);

            myparams[1] = new SqlParameter("@Answers", Answers_New);

            db.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);

            return RedirectToAction("List");
        }

        //TODO: EDIT VIEW, EDIT, DELETE, SHOW


        public async Task<ActionResult> Edit(int? id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 2)
            {
               // string query = "select * from Faqs where faqid=@id";
                SqlParameter param = new SqlParameter("@id", id);
                //Faq myfaq = db.Faqs.FromSql(query, param).FirstOrDefault();

                return NotFound();
            }
            else return RedirectToAction("Register", "Account");
        }




        /* public ActionResult Edit(int? id)
         {
             if ((id == null) || (db.Faqs.Find(id) == null))
             {
                 return NotFound();
             }
             string query = "select * from Faqs where faqid=@id";
             SqlParameter param = new SqlParameter("@id", id);
             Faq myfaq = db.Faqs.FromSql(query, param).FirstOrDefault();
             return View(myfaq);
         }*/



        [HttpPost]
        public async Task<ActionResult> Edit(int? id, string Question, string Answer)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            /* if (userstate == 0)
             {
                 return RedirectToAction("Register", "Account");
             }


             if ((id == null) || (db.Faqs.Find(id) == null))
             {
                 return NotFound();
             }*/
            if (userstate == 2)
            {
                string query = "update faqs set questions=@que, answers=@ans" +
                    " where FaqID=@id";
                SqlParameter[] myparams = new SqlParameter[3];
                myparams[0] = new SqlParameter("@que", Question);
                myparams[1] = new SqlParameter("@ans", Answer);
                myparams[2] = new SqlParameter("@id", id);

                db.Database.ExecuteSqlCommand(query, myparams);
            }

            return RedirectToAction("List");
        }



        public async Task<ActionResult> Delete(int? id)
        {

            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 2)
            {

                string query = "DELETE from faqs WHERE FaqID=@id";
                SqlParameter param = new SqlParameter("@id", id);

                db.Database.ExecuteSqlCommand(query, param);

                return RedirectToAction("List");
            }
            else return RedirectToAction("index", "Home");
        }

    }
}