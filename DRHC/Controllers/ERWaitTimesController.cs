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
    /*
    public class ERWaitTimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ERWaitTimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ERWaitTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ERWaitTime.ToListAsync());
        }

        // GET: ERWaitTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eRWaitTime = await _context.ERWaitTime
                .FirstOrDefaultAsync(m => m.ERWaitTimeId == id);
            if (eRWaitTime == null)
            {
                return NotFound();
            }

            return View(eRWaitTime);
        }

        // GET: ERWaitTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ERWaitTimes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ERWaitTimeId,WaitTime,Description")] ERWaitTime eRWaitTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eRWaitTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eRWaitTime);
        }

       
    }
    */
}
