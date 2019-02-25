using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GCTProject.Data;
using Microsoft.AspNetCore.Authorization;
using GCTProject.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Dynamic;
using System.Collections.Generic;
using Stripe;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GCTProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _contextId;
        private readonly GCTProjectContext _contextData;

        public AccountController(
                    UserManager<IdentityUser> userManager,
                    SignInManager<IdentityUser> signInManager,
                    ApplicationDbContext contextId,
                    GCTProjectContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextId = contextId;
            _contextData = context;
        }

        //GET Details for logged in user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string returnUrl = null)
        {
            
            var user = await _userManager.GetUserAsync(User);

            

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Details model = new Details();
            model.Email = user.Email;
            model.PhoneNumber = user.PhoneNumber;
            // model.FullName = user.FullName;
            model.IsEmailConfirmed = (bool)user.EmailConfirmed;

            //model.Password = null;
            //model.ConfirmPassword = null;

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

            //if (model.FullName != user.FullName)
            //{
            //    user.FullName = model.FullName;
            //}

            //if (model.Username != user.UserName)
            //{
            //    user.UserName = model.Username;
            //}
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
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //GET Lockout, not in use
        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }

        //GET Register User
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        ////POST RegisterAccount
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> RegisterAccount([Bind("Id", "Email", "CardNumber", "CVC", "ExpiryDate")]CardRegistration model, string stripeToken)
        //{
        //    var customers = new CustomerService();
        //    var charges = new ChargeService();
        //    if (stripeToken != null)
        //    {
        //        var customer = customers.Create(new CustomerCreateOptions
        //        {
        //            Email = model.Email,
        //            SourceToken = stripeToken
        //        });



        //        var charge = charges.Create(new ChargeCreateOptions
        //        {
        //            Amount = 500,
        //            Description = "Initial Charge",
        //            Currency = "gbp",
        //            CustomerId = customer.Id
        //        });
        //        if (model.CardNumber != null && model.CardNumber.Length == 16 && model.CVC != null && model.ExpiryDate != null)
        //        {
        //            try
        //            {
        //                Data.Account account = new Data.Account() { UserId = model.Id, CustomerId = customer.Id, ExpiryDate = model.ExpiryDate.ToShortDateString(), Last4 = model.CardNumber.Substring(12), Cvc = Int32.Parse(model.CVC) };
        //                _contextData.Update(account);
        //                await _contextData.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!AccountExists(model.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            _contextData.Account.Add(new Data.Account()
        //            {
        //                UserId = model.Id,
        //                //CustomerId = customer.Id,
        //                ExpiryDate = model.ExpiryDate.ToShortDateString(),
        //                Cvc = Int32.Parse(model.CVC),
        //                Last4 = model.CardNumber.Substring(12)
        //            });
        //        }
        //        return View();
        //    }
        //    _contextData.Account.Add(new Data.Account()
        //    {
        //        UserId = model.Id,
        //        //CustomerId = customer.Id,
        //        ExpiryDate = model.ExpiryDate.ToShortDateString(),
        //        Cvc = Int32.Parse(model.CVC),
        //        Last4 = model.CardNumber.Substring(12)
        //    });
        //    await _contextData.SaveChangesAsync();


        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}
        
        //POST Customers Registration Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email", "FirstName", "CustomerRegistration", "Surname", "Name", "FLAddress", "SLAddress", "PostCode",
            "Password", "ConfirmPassword","PhoneNumber", "DateOfBirth")] Register model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    var registeredUser = await _userManager.FindByEmailAsync(model.Email);
                    if (!model.CustomerRegistration)
                    {
                        await _userManager.AddToRoleAsync(user, "Customer");
                        _contextData.Customer.Add(new Data.Customer()
                        {
                            UserId = registeredUser.Id,
                            DateOfBirth = model.DateOfBirth,
                            Address = model.FLAddress + "=" + model.SLAddress + "=" + model.PostCode,
                            FullName = model.FirstName + " " + model.Surname
                        });

                        _contextData.Account.Add(new Data.Account() { UserId = registeredUser.Id });
                        _contextData.Basket.Add(new Basket() { UserId = registeredUser.Id, ShippingMethod = "Home Delivery" });
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "AgencyOrClub");
                        _contextData.AgencyOrClub.Add(new AgencyOrClub() { UserId = registeredUser.Id, Address = model.FLAddress + "=" + model.SLAddress + "=" + model.PostCode, Name = model.Name });
                        _contextData.Account.Add(new Data.Account() { UserId = registeredUser.Id });
                        _contextData.Basket.Add(new Basket() { UserId = registeredUser.Id, ShippingMethod = "Office Delivery" });
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _contextData.SaveChangesAsync();
                    ViewData["Email"] = model.Email;
                    ViewData["Id"] = registeredUser.Id;
                    return RedirectToAction(nameof(HomeController.Index), "Home"); ;
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        ////GET Account registration
        //public IActionResult RegisterAccount()
        //{
        //    return View();
        //}

        //POST Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return _contextData.Account.Any(e => e.UserId.Equals(id));
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