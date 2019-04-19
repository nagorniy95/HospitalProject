using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using DRHC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Controllers
{
    public class OrderController : Controller
    {
        private readonly DrhcCMSContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


        public OrderController(DrhcCMSContext context, UserManager<ApplicationUser> usermanager)
        {
            db = context;
            _userManager = usermanager;
        }


        public async Task<int> GetUserDetails(ApplicationUser user)
        {
            if (user == null) return 0;

            if (user.AdminID == null) return 1; //User is not admin author
            else return 2;

            return -1;//something went wrong
        }

        
        public ActionResult New()
        {
            OrderEdit oe = new OrderEdit();
            oe.Guests = db.Guests.ToList();
            var guestcount = oe.Guests.Count();
            oe.Menus = db.Menus.ToList();
            var menucount = oe.Menus.Count();
            if (guestcount == 0) return RedirectToAction("New", "Guest");
            else if (menucount ==0) return RedirectToAction("New", "Menu");
            else return View(oe);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string UserFName, string UserLName, string Email,
                        string Number, string Date, string Time, float Veg, float NonVeg,
                        int? GuestID, int?[] FoodItems)
        {
            //adding order details in order table
            string query = "insert into orders (UserFName,  UserLName,  Email," +
                         "Number, Date,  Time,  Veg,  NonVeg,GuestID) " +
                "values (@UserFName,  @UserLName,@Email," +
                         "@Number, @Date,  @Time,  @Veg,@NonVeg,@GuestID)";

            SqlParameter[] myparams = new SqlParameter[9];
            myparams[0] = new SqlParameter("@UserFName", UserFName);
            myparams[1] = new SqlParameter("@UserLName", UserLName);
            myparams[2] = new SqlParameter("@Email", Email);
            myparams[3] = new SqlParameter("@Number", Number);
            myparams[4] = new SqlParameter("@Date", Date);
            myparams[5] = new SqlParameter("@Time", Time);
            myparams[6] = new SqlParameter("@Veg", Veg);
            myparams[7] = new SqlParameter("@NonVeg", NonVeg);
            myparams[8] = new SqlParameter("@GuestID", GuestID);
            db.Database.ExecuteSqlCommand(query, myparams);
            
                 var order = await db.Orders.ToListAsync();
                 if (order.Count() != 0)
                 {
                     int oid = (int)order.Max(o => o.OrderID);
                     if ((FoodItems != null) && (FoodItems.Count() > 0))
                     {
                         foreach (int itemid in FoodItems)
                         {
                             string menuquerry = "insert into OrderXMenus (OrderID,ItemID) " +
                                 "values (@oid,@itemid)";
                             SqlParameter[] myparam = new SqlParameter[2];
                             myparam[0] = new SqlParameter("@itemid", itemid);
                             myparam[1] = new SqlParameter("@oid", oid);

                             db.Database.ExecuteSqlCommand(menuquerry, myparam);
                             
                         }


                     }
                 }

                return RedirectToAction("New");
        }


        public async Task<ActionResult> List(int pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }

            /*Pagination Algorithm*/
            var orders = await db.Orders.Include(o => o.Guests).Include(o => o.Ordersxmenus).ThenInclude(oxt => oxt.Menu).ToListAsync();

            int count = orders.Count();
            int perpage = 4;
            int maxpage = (int)Math.Ceiling((decimal)count / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = perpage * pagenum;
            ViewData["pagenum"] = (int)pagenum;
            ViewData["PaginationSummary"] = "";
            if (maxpage > 0)
            {
                ViewData["PaginationSummary"] =
                    (pagenum + 1).ToString() + " of " +
                    (maxpage + 1).ToString();
            }

            List<Order> or = await db.Orders.Include(o => o.Guests).Include(o => o.Ordersxmenus).ThenInclude(oxt => oxt.Menu).Skip(start).Take(perpage).ToListAsync();


            return View(or);

        }

        public async Task<ActionResult> Show(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 0)
            {
                return RedirectToAction("Register", "Account");
            }
            var order = db.Orders.Include(o => o.Guests).Include(o => o.Ordersxmenus).ThenInclude(oxt => oxt.Menu).SingleOrDefault(o => o.OrderID == id);

            return View(order);


        }



        public ActionResult Delete(int id,int? pagenum)
        {
            string query = "delete from OrderXMenus where OrderID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            string orderquery = "delete from orders where OrderID = @id";
            db.Database.ExecuteSqlCommand(orderquery, new SqlParameter("@id", id));


            return RedirectToAction("List/?pagenum=" + pagenum);



        }
    }
  }