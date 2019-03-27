using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GCTOnlineServices.Models;
using Microsoft.AspNetCore.Authorization;
using GCTOnlineServices.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using GCTOnlineServices.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GCTOnlineServices.Models.OOPModels;

namespace GCTOnlineServices.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GCTContext _context;
        private readonly IMapper _mapper;

        public AccountController(
                    UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    GCTContext context, IMapper mapper
                    )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;

        }

        //GET Details for logged in user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string returnUrl = null)
        {

            var user = await _userManager.GetUserAsync(User);

            var role = _userManager.GetRolesAsync(user);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            Details model = new Details
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = (bool)user.EmailConfirmed
            };

            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        //Update Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details(Details model, string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }


        //GET Login/Account
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        //POST submit login attempt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        model.Password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        //ViewBag.ErrorLog = "Invalid username or password";
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                    }

                } catch (NullReferenceException nre)
                {
                    return View(model);
                }
                    
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //Register User
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST Customers Registration Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email", "FirstName", "CustomerRegistration", "Surname", "Name", "FLAddress", "SLAddress", "PostCode",
            "Password", "ConfirmPassword","PhoneNumber", "DateOfBirth")] Register model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    Address = model.FLAddress.Trim() + "," + model.SLAddress.Trim() + "," + model.PostCode.Trim(),
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);


                if (result.Succeeded)
                {
                    var registeredUser = await _userManager.FindByEmailAsync(model.Email);
                    // check customer or agency
                    if (!model.CustomerRegistration)
                    {
                        //assign values for customer
                        registeredUser.DateOfBirth = model.DateOfBirth;
                        registeredUser.FirstName = model.FirstName;
                        registeredUser.LastName = model.Surname;

                        _context.Users.Update(registeredUser);

                        await _userManager.AddToRoleAsync(newUser, "Customer");
                        
                        _context.Basket.Add(new Basket() { UserId = registeredUser.Id, ShippingMethod = registeredUser.Address });
                        
                    }
                    else
                    {
                        registeredUser.Id = registeredUser.Id;
                        registeredUser.AgencyOrClubName = model.Name;
                        registeredUser.ApprovedMultipleDiscounts = false;
                        
                        // assign values for agency
                        await _userManager.AddToRoleAsync(newUser, "AgencyOrClub");
                        _context.Users.Update(registeredUser);
                        _context.Basket.Add(new Basket() { UserId = registeredUser.Id, ShippingMethod = "Office Delivery" });
                        
                    }
                    try
                    {
                        await _signInManager.SignInAsync(newUser, isPersistent: false);
                    } catch(Exception ex)
                    {
                        return BadRequest();
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(HomeController.Index), "Home"); ;
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // action to log out the user and redirect to the index page
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #region Helpers
        //Add errors to models
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        private bool AccountExists(string id)
        {
            return _context.Users.Any(e => e.Id.Equals(id));
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}