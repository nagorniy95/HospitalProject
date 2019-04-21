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
    
    public class DonationController : Controller
    {

        private readonly DrhcCMSContext db;


        public DonationController(DrhcCMSContext context)
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

            string query = "select * from Donations";
            IEnumerable<Donation> donations;

            donations = db.Donations.FromSql(query);
            return View(donations);
        }



        // GET: Donations/Create
        public IActionResult New() => View();

        // POST: Donations/Create

        

        [HttpPost]
        public ActionResult Create(string Title, string FirstName, string LastName, string Address, string City, string Province, string PostalCode, string Email, string Phone, double Amount)
        {
            string query = "insert into Donations (Title, FirstName, LastName, Address, City, Province, PostalCode, Email, Phone, Amount)" +
                " values (@Title, @FirstName, @LastName, @Address, @City, @Province, @PostalCode, @Email, @Phone, @Amount)";
            SqlParameter[] myparams = new SqlParameter[11];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@FirstName", FirstName);
            myparams[2] = new SqlParameter("@LastName", LastName);
            myparams[3] = new SqlParameter("@Address", Address);
            myparams[4] = new SqlParameter("@City", City);
            myparams[5] = new SqlParameter("@Province", Province);
            myparams[6] = new SqlParameter("@PostalCode", PostalCode);
            myparams[7] = new SqlParameter("@Email", Email);
            myparams[9] = new SqlParameter("@Phone", Phone);
            myparams[10] = new SqlParameter("@Amount", Amount);




            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

    }

}
