using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GCTOnlineServices.Models;
using GCTOnlineServices.Models.ViewModels;

namespace GCTProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GCTContext _contextData;

        public UsersController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    GCTContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextData = context;
        }

        // return all the users
        public async Task<IActionResult> Index()
        {
            return View(await _contextData.Users.ToListAsync());
        }

        // view details of users
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // create a staff user
        public IActionResult Create()
        {
            return View();
        }

        // submit the details of the new member of staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Number,Name,Password," +
            "ConfirmPassword")]RegisterStaff Staff)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { Email = Staff.Email, UserName = Staff.Name };
                var result = await _userManager.CreateAsync(user, Staff.Password);
                if (result.Succeeded)
                {
                    var registeredUser = await _userManager.FindByEmailAsync(Staff.Email);
                    await _userManager.AddToRoleAsync(user, "SalesStaff");
                    
                    
                    }
                    return RedirectToAction(nameof(Index));
            }
            return View(Staff);
        }

        // edit the details of a user
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.Users.FindAsync(id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // submit all the changes to a user details
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

        // delete a user
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _contextData.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // confirm user deleted
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ApplicationUser = await _contextData.Users.FindAsync(id);
            _contextData.Users.Remove(ApplicationUser);
            await _contextData.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //check if user exists
        private bool ApplicationUserExists(string id)
        {
            return _contextData.Users.Any(e => e.Id == id);
        }
    }
}
