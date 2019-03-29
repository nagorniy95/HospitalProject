using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DRHC.Models;
using DRHC.Data;

namespace DRHC.Controllers
{
    public class AlertsController : Controller
    {
        private readonly DrhcCMSContext db;

        public AlertsController(DrhcCMSContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //================================================================================= Read

        public ActionResult List()
        {
            string query = "select * from Alerts";

            IEnumerable<Alerts> alerts;
            alerts = db.alerts.FromSql(query);

            return View(alerts);
        }
        //================================================================================= Create

        public ActionResult New()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string AlertTitle, string AlertMessage)
        {
            string query = "insert into Alerts (AlertTitle, AlertMessage)" +
                " values (@title, @message)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@title", AlertTitle);
            myparams[1] = new SqlParameter("@message", AlertMessage);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Edit

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.alerts.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from Alerts where AlertID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Alerts mytag = db.alerts.FromSql(query, param).FirstOrDefault();
            return View(mytag);
        }


        [HttpPost]
        public ActionResult Edit(int? id, string AlertTitle, string AlertMessage)
        {
            if ((id == null) || (db.alerts.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update Alerts set AlertTitle=@title,AlertMessage=@mess" +
                " where AlertID=@id";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@title", AlertTitle);
            myparams[1] = new SqlParameter("@mess", AlertMessage);
            myparams[2] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //================================================================================= Delete


        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.alerts.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from Alerts where AlertID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");

        }
    }
}