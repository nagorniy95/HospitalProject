using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DRHC.Data;
using DRHC.Models;

namespace Myfeatures.Controllers
{
    
    public class JobApplicationController : Controller
    {   /*
        private readonly ApplicationDbContext _context;

        public JobApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobApplication.Include(j => j.JobPostings);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplication
                .Include(j => j.JobPostings)
                .FirstOrDefaultAsync(m => m.JobApplicationID == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            ViewData["JobPostingId"] = new SelectList(_context.JobPosting, "JobPostingID", "JobTitle");
            return View();
        }

        // POST: JobApplications/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobApplicationID,FirstName,LastName,Email,Address,City,Province,PostalCode,Phone,AppDate,Status,Position,Resume,Coverletter,JobPostingId")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobPostingId"] = new SelectList(_context.JobPosting, "JobPostingID", "JobTitle", jobApplication.JobPostingId);
            return View(jobApplication);
        }*/
    }
    
}