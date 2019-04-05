﻿using System;
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
using DRHC.Models.ViewModels;
using DRHC.Data;

namespace DRHC.Controllers
{
    
    public class VolunteerPositionController : Controller
    {
        /*
        private readonly DrhcCMSContext db;

        public VolunteerPositionController(DrhcCMSContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("ListVolunteerPositions");
        }

        public ActionResult List()
        {
            List<VolunteerPosition> volunteerPositions = db.VolunteerPosition.ToList();

            return View(VolunteerPositions);
            //what return do I need here?
        }

        public ActionResult New()
        {
            //need the view model
        }

        // why error for create
        [HttpPost]
        public ActionResult Create(string PostTitle_New, string Department_New, string Description_New, string AboutOrg_New, string Experience_New, string Education_New)
        {
            string query = "insert into VolunteerPositions (PostTitle, Department, Description, AboutOrg, Experience, Education) values (@posttitle, @department, @description, @aboutorg, @experience, @education)";

            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@posttitle", PostTitle_New);
            myparams[1] = new SqlParameter("@department", Department_New);
            myparams[2] = new SqlParameter("@description", Description_New);
            myparams[3] = new SqlParameter("@aboutorg", AboutOrg_New);
            myparams[4] = new SqlParameter("@experience", Experience_New);
            myparams[5] = new SqlParameter("@education", Education_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("ListVolunteerPositions");
        }

        public ActionResult Edit(int id)
        {
            //new viewmodel
        }

        [HttpPost]
        public ActionResult Edit(int id, string PostTitle, string Department, string Description, string AboutOrg, string Experience, string Education)
        {
            if ((id == null) || (db.VolunteerPositions.Find(id) == null))
            {
                return NotFound();

            }
            string query = "update VolunteerPositions set PostTitle=@posttitle, Department=@department, Description=@description, AboutOrg=@aboutorg, Experience=@experience, Education=@education";

            SqlParameter[] myparams = new SqlParameter[7];

            myparams[0] = new SqlParameter("@posttitle", PostTitle);
            myparams[1] = new SqlParameter("@department", Department);
            myparams[2] = new SqlParameter("@description", Description);
            myparams[3] = new SqlParameter("@aboutorg", AboutOrg);
            myparams[4] = new SqlParameter("@experience", Experience);
            myparams[5] = new SqlParameter("@education", Education);
            myparams[6] = new SqlParameter("@id", id);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("/" + id); 
            //Do I need a show for Positions?
        }
        /*public ActionResult Show(int? id)
        {} Do I need a show? */
        /*
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.VolunteerPositions.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from VolunteerPositions where VolunteerPostingID = @id";

            SqlParameter myparam = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparam);

            return RedirectToAction("ListVolunteerPositions");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }



    /*
    public IActionResult Index()
    {
        return View();
    }*/
    }
}