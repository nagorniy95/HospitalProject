using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using DRHC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

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
            if (user.AdminID != null) return 2; //User is not admin author

            else return -1;
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


                return RedirectToAction("SendOrderSummary/" + oid);
            }
            return RedirectToAction("index","Home");
        }


        public async Task<ActionResult> List(int pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);

            if (userstate == 2)
            {

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
            else return View("Index", "Home");


        }

        public async Task<ActionResult> Show(int id)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {

                Order order = db.Orders.Include(o => o.Guests).Include(o => o.Ordersxmenus).ThenInclude(oxt => oxt.Menu).SingleOrDefault(o => o.OrderID == id);
                double total = 0;
                foreach (var f in order.Ordersxmenus)
                {
                    total = total + Convert.ToDouble(f.Menu.Price);
                    //total = total + Convert.ToInt32(Convert.ToDouble(f.Menu.Price, CultureInfo.InvariantCulture));

                    //total = total + int.Parse(f.Menu.Price);
                }
                double vat = total * 0.13;
                double grandtotal = vat + total;
                ViewData["subtotal"] = total;
                ViewData["vat"] = "13%";
                ViewData["Total"] = grandtotal;
                return View(order);
            }
            else  return RedirectToAction("index", "Home");



        }



        public async Task<ActionResult> Delete(int id,int? pagenum)
        {
            var user = await GetCurrentUserAsync();
            var userstate = await GetUserDetails(user);
            if (userstate == 2)
            {

                string query = "delete from OrderXMenus where OrderID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            string orderquery = "delete from orders where OrderID = @id";
            db.Database.ExecuteSqlCommand(orderquery, new SqlParameter("@id", id));


            return RedirectToAction("List/?pagenum=" + pagenum);
            }
            else return RedirectToAction("index", "Home");


        }


        //sending confirmation of order
        public ActionResult SendOrderSummary(int id)
        {
            
            Order o = db.Orders.Include(order => order.Ordersxmenus).ThenInclude(oxt => oxt.Menu).SingleOrDefault(order => order.OrderID == id);
            string summary = "-----------------------------------<br/>";

            summary += "<h2>Thankyou "+o.UserFName+" "+o.UserLName+" for ordering</h2><br/>";
            summary += "-----------------------------------<br/>";

            summary += "<h3>:::::::Your Order Details are::::::::</h3>";
            summary += "<p>Event Date: "+o.Date +"| Event Time: "+o.Time+"</p>";
            summary += "<p>:::::::Your contact details :: <p/>";
            summary += "<p>Phone : " + o.Number + "|  Email: " + o.Email + "</p>";

            double total = 0;
            foreach ( var f in o.Ordersxmenus)
            {
                total = total + Convert.ToDouble(f.Menu.Price);

                summary += f.Menu.ItemName +" :: " + f.Menu.Price+"<br/>";
            }

            double vat = total * 0.13;
            double grandtotal = vat + total;
            summary += "-----------------------------------<br/>";

            summary += "<div>Subtotal :: $" + total + "</div>";
            summary += "<div>Vat :: 13%</div>";
            summary += "-----------------------------------<br/>";

            summary += "<div>Total :: $"+ grandtotal +"</div>";
            summary += "-----------------------------------<br/>";



            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("admin", "wdn01269796@gmail.com"));
            msg.To.Add(new MailboxAddress(o.UserFName,o.Email));
            msg.Subject = "Order Detail";
            msg.Body = new TextPart("html")
            {
                Text = summary
            };


            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("wdn01269796@gmail.com", "mailtest1234");
                client.Send(msg);
                client.Disconnect(true);



            }


            return RedirectToAction("List");

        }

    }
}