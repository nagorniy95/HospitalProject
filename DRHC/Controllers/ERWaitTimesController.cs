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

        //added this to display ER wait time
        public IActionResult Display()
        {
            return View();
        }

        public ActionResult List()
        {

            string query = "select * from ERWaitTimes";
            IEnumerable<ERWaitTime> eRWaitTimes;

            eRWaitTimes = db.ERWaitTimes.FromSql(query);
            return View(eRWaitTimes);
        }
        // GET: ERWaitTimes
        public async Task<IActionResult> Show()
        {
            return View(await db.ERWaitTimes.ToListAsync());
        }

        // GET: ERWaitTimes/Create
        public IActionResult New() => View();

        // POST: ERWaitTimes/Create
        [HttpPost]
        public ActionResult Create(string WaitTimeCat, string Description)
        {
            string query = "insert into ERWaitTimes (WaitTimeCat, Description)" +
                " values (@WaitTimeCat, @Description)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@WaitTimeCat", WaitTimeCat);
            myparams[1] = new SqlParameter("@Description", Description);
           

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

        public ActionResult Edit(int id, string WaitTimeCat, string Description)
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
