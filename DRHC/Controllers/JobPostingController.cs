using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    
    public class JobPostingController : Controller
    {
        private readonly DrhcCMSContext db;


        public JobPostingController(DrhcCMSContext context)
        {
            db = context;
        }


        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //View

        public ActionResult List()
        {

            string query = "select * from JobPostings";
            IEnumerable<JobPosting> jobPostings;

            jobPostings = db.JobPostings.FromSql(query);
            return View(jobPostings);
        }

        // GET: Job Postings/Create
        public IActionResult New() => View();

        // POST: Job Posstings/Create
        [HttpPost]
        public ActionResult Create(string JobTitle, string Department, DateTime Now, DateTime DeadlineToApply, string Description, string AboutOrg, string AboutPosition, string Experience, string Education)
        {
            string query = "insert into JobPostings (JobTitle, Department, Now, DeadlineToApply,Description,AboutOrg, AboutPosition, Experience, Education  )" +
                " values (@JobTitle, @Department, @Now, @DeadlineToApply, @Description, @AboutOrg, @AboutPosition, @Experience, @Education)";
            SqlParameter[] myparams = new SqlParameter[9];
            myparams[0] = new SqlParameter("@JobTitle ", JobTitle);
            myparams[1] = new SqlParameter("@Department", Department);
            myparams[2] = new SqlParameter("@Now", Now);
            myparams[3] = new SqlParameter("@DeadlineToApply", DeadlineToApply);
            myparams[4] = new SqlParameter("@Description ", Description);
            myparams[5] = new SqlParameter("@AboutOrg", AboutOrg);
            myparams[6] = new SqlParameter("@AboutPosition", AboutPosition);
            myparams[7] = new SqlParameter("@Experience", Experience);
            myparams[8] = new SqlParameter("@Education", Education);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }


    }

}

