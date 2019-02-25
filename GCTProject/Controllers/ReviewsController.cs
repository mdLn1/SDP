using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCTProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GCTProject.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly GCTProjectContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(GCTProjectContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reviews
        [AllowAnonymous]
        public async Task<IActionResult> Index(string Id=null)
        {
            if(Id == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var performance = await _context.Performance.FirstOrDefaultAsync(x => x.Id == Id);
            @ViewData["PerformanceName"] = performance.Name;
            @ViewData["PerformanceDescription"] = performance.Description;
            @ViewData["PerformanceId"] = performance.Id;

            var gCTProjectContext = _context.Review.Where(x => x.PerformanceId == Id).Include(r => r.Performance).Include(r => r.User);
            return View(await gCTProjectContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.Performance)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create(string id = null)
        {
            Review review = new Review
            {
                PerformanceId = id
            };
            return View(review);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerformanceId,Comment")] Review review)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                review.UserId = user.Id;
                review.UserName = user.UserName;
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["PerformanceId"] = new SelectList(_context.Performance, "Id", "Id", review.PerformanceId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", review.UserId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PerformanceId,UserId,UserName,Comment,Date")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformanceId"] = new SelectList(_context.Performance, "Id", "Id", review.PerformanceId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", review.UserId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.Performance)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.FindAsync(id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
