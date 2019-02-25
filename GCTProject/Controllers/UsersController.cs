using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCTProject;
using GCTProject.Data;
using GCTProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace GCTProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _contextId;
        private readonly GCTProjectContext _contextData;

        public UsersController(UserManager<IdentityUser> userManager,
                    SignInManager<IdentityUser> signInManager,
                    ApplicationDbContext contextId,
                    GCTProjectContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextId = contextId;
            _contextData = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _contextData.AspNetUsers.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Number,Name,Password,ConfirmPassword")] RegisterStaff Staff)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { Email = Staff.Email, UserName = Staff.Name };
                var result = await _userManager.CreateAsync(user, Staff.Password);
                if (result.Succeeded)
                {
                    var registeredUser = await _userManager.FindByEmailAsync(Staff.Email);
                    await _userManager.AddToRoleAsync(user, "SalesStaff");
                    _contextData.StaffMembers.Add(new StaffMembers
                    {
                        UserId = registeredUser.Id,
                        Number = Staff.Number
                        });
                    
                    }
                    return RedirectToAction(nameof(Index));
            }
            return View(Staff);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.AspNetUsers.FindAsync(id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Email,PhoneNumber")] IdentityUser ApplicationUser)
        {
            if (id != ApplicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextData.Update(ApplicationUser);
                    await _contextData.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(ApplicationUser.Id))
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
            return View(ApplicationUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ApplicationUser = await _contextData.AspNetUsers.FindAsync(id);
            _contextData.AspNetUsers.Remove(ApplicationUser);
            await _contextData.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _contextData.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
