using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DRHC.Data;
using DRHC.Models;

namespace DRHC.Controllers
{   
    
    public class DonationController : Controller
    {   
        /*
        private readonly ApplicationDbContext _context;

        public DonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Donation.Include(d => d.Donors);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donation
                .Include(d => d.Donors)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "Email");
            return View();
        }

        // POST: Donations/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,AppDate,Amount,DonorId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "Email", donation.DonorId);
            return View(donation);
        }

     */  
    }
    
}
