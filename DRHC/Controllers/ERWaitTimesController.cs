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
    
    public class ERWaitTimeController : Controller
    {
        private readonly DrhcCMSContext db;

        
        public ERWaitTimeController(DrhcCMSContext context)
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

            string query = "select * from ERWaitTimes";
            IEnumerable<ERWaitTime> eRWaitTimes;

            eRWaitTimes = db.ERWaitTimes.FromSql(query);
            return View(eRWaitTimes);
        }

        // GET: ERWaitTimes/Create
        public IActionResult New() => View();

        // POST: ERWaitTimes/Create
        [HttpPost]
        public ActionResult Create(string WaitTimeCat, string StartDateTime, string EndDateTime, string Description)
        {
            string query = "insert into ERWaitTimes (WaitTimeCat, StartDateTime, EndDateTime, Description)" +
                " values (@WaitTimeCat, @StartDateTime, @EndDateTime, @Description)";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@WaitTimeCat", WaitTimeCat);
            myparams[1] = new SqlParameter("@StartDateTime", StartDateTime);
            myparams[2] = new SqlParameter("@EndDateTime", EndDateTime);
            myparams[3] = new SqlParameter("@Description", Description);
           

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        
       
    }
    
}
