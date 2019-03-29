using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class TipAndLetterController : Controller
    {
        //makes a BlogCMSContext
        private readonly DrhcCMSContext db;
        //constructor function which takes a BlogCMSContext as a constructor.
        //Q: How does the Controller just *get* this context?
        //A: "magic" called dependency injection will put the data there.
        public TipAndLetterController(DrhcCMSContext context)
        {
            db = context;
        }

        public ActionResult New()
        {
            TipAndLetterEdit tl = new TipAndLetterEdit();
            //[db.Pages]=> get page data.
            //[.Include(p=>p.pagesxtags)]=> include (tags) data for page.
            //[.SingleOrDefault(p => p.PageID == id)]=> include the pages' blog. 
            // and Take the one where the ID matches GET parameter
            //get all blog data
            tl.Tags = db.Tags.ToList();
            //get all tag data
            tl.TipStatuss = db.TipStatuss.ToList();

            return View(tl);
        }
        //Restricts this method to only handle POST
        //eg. POST to /Pages/Create/
        [HttpPost]
        public ActionResult Create(string Title, string Message, int? TagID, int? TipStatusID)
        {
            string query = "insert into TipAndLetters (Title, Message, TagID,TipStatusID) " +
                "values (@Title, @Message, @Title,@TipStatusID)";

            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@Title", Title);
            myparams[1] = new SqlParameter("@Message", Message);
            myparams[2] = new SqlParameter("@TagID", TagID);
            myparams[3] = new SqlParameter("@TipStatusID", TipStatusID);

            db.Database.ExecuteSqlCommand(query, myparams);
            //testing that the paramters do indeed pass to the method
            //Debug>Windows>Output
            Debug.WriteLine(query);
            return RedirectToAction("List");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.TipAndLetters.ToList());
        }
    }
}