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


        // GET: ERWaitTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            //Debug.WriteLine("testing driver edit");
            if ((id == null) || (db.ERWaitTimes.Find(id) == null))
            {
                 return NotFound();
            }
            string query = "select * from ERWaitTimes where ERWaitTimeId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            ERWaitTime mywaittime = db.ERWaitTimes.FromSql(query, param).FirstOrDefault();
            return View(mywaittime);
        }
        // POST: ERWaitTime/Edit/5
        

        [HttpPost]

        public ActionResult Edit(int id, string WaitTimeCat, string Description, DateTime StartDateTime, DateTime EndDateTime)
        {

            if ((id == null) || (db.ERWaitTimes.Find(id)) == null)
            {
                return NotFound();
            }

            string query = "update ERWaitTimes set WaitTimeCat=@WaitTimeCat, Description=@Description, StartDateTime = @StartDateTime, EndDateTime = @EndDateTime where ERWaitTimeId = @id";
            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@id", id);
            myparams[1] = new SqlParameter("@WaitTimeCat", WaitTimeCat);
            myparams[2] = new SqlParameter("@Description", Description);
            myparams[3] = new SqlParameter("@StartDateTime", StartDateTime);
            myparams[4] = new SqlParameter("@EndDateTime", EndDateTime);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        
        // GET: ERWaitTime/Delete


        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.ERWaitTimes.Find(id) == null))
            {
                return NotFound();
            }
            string query = "delete from ERWaitTimes where ERWaitTimeId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");

        }
    }
}
