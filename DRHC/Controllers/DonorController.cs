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

namespace Myfeatures.Controllers
{
    
    public class DonorController : Controller
    {
        private readonly DrhcCMSContext db;


        public DonorController(DrhcCMSContext context)
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

            string query = "select * from Donors";
            IEnumerable<Donor> donors;

            donors = db.Donors.FromSql(query);
            return View(donors);
        }

       

        // GET: Donors/Create
        public IActionResult New() => View();

        // POST: Donors/Create

        [HttpPost]
        public ActionResult Create(string Title, string FirstName, string LastName, string Address, string City, string Province, string PostalCode, string Email, string Phone)
        {
            string query = "insert into Donors (Title,FirstName,LastName,Address,City,Province,PostalCode,Email,Phone)" +
                " values (@Title,@FirstName,@LastName,@Address,@City,@Province,@PostalCode,@Email,@Phone)";
            SqlParameter[] myparams = new SqlParameter[9];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@FirstName", FirstName);
            myparams[2] = new SqlParameter("@LastName", LastName);
            myparams[3] = new SqlParameter("@Address", Address);
            myparams[4] = new SqlParameter("@City", City);
            myparams[5] = new SqlParameter("@Province", Province);
            myparams[6] = new SqlParameter("@PostalCode", PostalCode);
            myparams[7] = new SqlParameter("@Email", Email);
            myparams[8] = new SqlParameter("@Phone", Phone);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

    }
    
}
