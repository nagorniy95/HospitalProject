using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRHC.Data;
using DRHC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DRHC.Controllers
{
    /*
    public class JobPostingController : Controller
    {/*
        private readonly ApplicationDbContext _context;

        

        public JobPostingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobPostings
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobPosting.ToListAsync());
        }

        // GET: JobPostings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPosting
                .FirstOrDefaultAsync(m => m.JobPostingID == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        // GET: JobPostings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobPostings/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobPostingID,JobTitle")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobPosting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobPosting);
        }
        */
    }
    */
}