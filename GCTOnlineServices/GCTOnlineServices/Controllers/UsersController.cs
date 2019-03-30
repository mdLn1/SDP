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
using GCTOnlineServices.Helpers;

namespace GCTProject.Controllers
{
    // controller class that only manager can access
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GCTContext _context;

        public UsersController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    GCTContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // return all the users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        //return all agencies
        public async Task<IActionResult> GetAgencies()
        {
            var agencies = await _context.ApplicationUsers.Where(x => x.ApprovedMultipleDiscounts != null).ToListAsync();

            return View(agencies);
        }

        // approve agency discount
        public async Task<IActionResult> ApproveAgency(string id)
        {
            var agency = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (agency == null)
            {
                return RedirectToAction(nameof(GetAgencies));
            }
            agency.ApprovedMultipleDiscounts = true;
            _context.ApplicationUsers.Update(agency);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(GetAgencies));

        }

        // cancel discount for agency
        public async Task<IActionResult> CancelAgencyDiscount(string id)
        {
            var agency = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (agency == null)
            {
                return RedirectToAction(nameof(GetAgencies));
            }
            agency.ApprovedMultipleDiscounts = false;
            _context.ApplicationUsers.Update(agency);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GetAgencies));

        }


        // view details of users
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // view to create a staff user 
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
                var user = new ApplicationUser() { Email = Staff.Email, UserName = Staff.Name, IdNumber = Staff.Number };
                var result = await _userManager.CreateAsync(user, Staff.Password);
                if (result.Succeeded)
                {
                    var registeredUser = await _userManager.FindByEmailAsync(Staff.Email);
                    await _userManager.AddToRoleAsync(user, "SalesStaff");
                    _context.Basket.Add(new Basket() { ShippingMethod = "Collection Booth", UserId = user.Id, TotalPrice = 0 });

                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TempData["UserNotifier"] = new UserNotifier()
            {
                CssFormat = "alert-danger",
                MessageType = "Error!",
                Content = "User wa not created."
            };
            return View(Staff);
        }
        
        // edit the details of a user
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.Users.FindAsync(id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }
        
        // submit all the changes to user details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Email,PhoneNumber")] ApplicationUser ApplicationUser)
        {
            if (id != ApplicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ApplicationUser);
                    await _context.SaveChangesAsync();
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

            var ApplicationUser = await _context.Users
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
            var ApplicationUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(ApplicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //check if user exists
        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
