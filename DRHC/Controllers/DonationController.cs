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
        public ActionResult Create(string AppDate, decimal Amount)
        {
            string query = "insert into Donations (AppDate,Amount)" +
                " values (@AppDate,@Amount)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@AppDate", AppDate);
            myparams[1] = new SqlParameter("@Amount", Amount);
            


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

    }

}
