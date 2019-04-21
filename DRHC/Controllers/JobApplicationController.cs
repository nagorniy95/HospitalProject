using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DRHC.Data;
using DRHC.Models;
using System.Data.SqlClient;

namespace DRHC.Controllers
{
    
    public class JobApplicationController : Controller
    {   
        private readonly DrhcCMSContext db;

        public JobApplicationController(DrhcCMSContext context)
        {
            db = context;
        }

        
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // view
        public ActionResult List()
        {

            string query = "select * from JobApplications";
            IEnumerable<JobApplication> jobApplications;

            jobApplications = db.JobApplications.FromSql(query);
            return View(jobApplications);
        }

        
        // GET: Job Postings/Create
        public IActionResult New() => View();

        // POST: Job Posstings/Create
        [HttpPost]
        public ActionResult Create(string FirstName, string LastName, string Email, string Address, string City, string Province, string PostalCode, string Phone, string Resume, string Coverletter)
        {
            string query = "insert into JobApplications (FirstName, LastName, Email, Address, City, Province,PostalCode,Phone, Resume, Coverletter)" +
                " values (@FirstName, @LastName, Email, @Address, @City, @Province,@PostalCode,@Phone, @Resume, @Coverletter)";
            SqlParameter[] myparams = new SqlParameter[10];
            myparams[0] = new SqlParameter("@FirstName ", FirstName);
            myparams[1] = new SqlParameter("@LastName", LastName);
            myparams[2] = new SqlParameter("@Email", Email);
            myparams[3] = new SqlParameter("@Address", Address);
            myparams[4] = new SqlParameter("@City ", City);
            myparams[5] = new SqlParameter("@Province", Province);
            myparams[6] = new SqlParameter("@PostalCode", PostalCode);
            myparams[7] = new SqlParameter("@Phone", Phone);
            myparams[8] = new SqlParameter("@Resume", Resume);
            myparams[9] = new SqlParameter("@Coverletter", Coverletter);



            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }


    }

}