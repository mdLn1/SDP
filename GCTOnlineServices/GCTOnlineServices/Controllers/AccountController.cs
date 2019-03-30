using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GCTOnlineServices.Models;
using Microsoft.AspNetCore.Authorization;
using GCTOnlineServices.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using AutoMapper;
using GCTOnlineServices.Helpers;

namespace GCTOnlineServices.Controllers
{
    // controller class for handling registration, login and user details changes
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
            // get user
            var user = await _userManager.GetUserAsync(User);
            
            // get role
            var role = _userManager.GetRolesAsync(user).ToAsyncEnumerable();
            // if user not found
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            // assign user properties to EditDetails Model
            EditUserDetails edit = _mapper.Map<EditUserDetails>(user);
            if (user.Address != null)
            {
                string[] address = user.Address.Split(",");
                edit.FLAddress = address[0];
                edit.SLAddress = address[1];
                edit.PostCode = address[2];
            }
            if (user.SavedCustomerCard != null)
            {
                edit.RemoveSavedCard = false;
            }
            else
            {
                edit.RemoveSavedCard = true;
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View(edit);
        }

        //Update Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details(EditUserDetails model, string returnUrl = null)
        {
            // find the user to be updated
            var user = await _userManager.FindByIdAsync(model.Id);

            // if not found, send to not gound page
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // check if model valid
            if (ModelState.IsValid)
            {
                try
                {
                    // update user details
                    user.AgencyOrClubName = model.AgencyOrClubName;
                    user.DateOfBirth = model.DateOfBirth;
                    user.FirstName = model.FirstName;
                    user.Email = model.Email;
                    user.LastName = model.LastName;
                    user.IdNumber = model.IdNumber;
                    user.UserName = model.Email;
                    user.Address = model.FLAddress + "," + model.SLAddress + "," + model.PostCode;
                    if (model.RemoveSavedCard == true)
                    {
                        user.SavedCustomerCard = null;
                    }

                    //save details
                    await _userManager.UpdateAsync(user);

                    // refresh sign in session
                    await _signInManager.RefreshSignInAsync(user);

                    ViewData["ReturnUrl"] = returnUrl;


                    TempData["UserNotifier"] = new UserNotifier()
                    {
                        CssFormat = "alert-success",
                        MessageType = "Success!",
                        Content = "Details successfully update"
                    };
                    return View(model);
                }
                catch (Exception e)
                {
                    // if exception occurs, let user know
                    TempData["UserNotifier"] = new UserNotifier()
                    {
                        CssFormat = "alert-error",
                        MessageType = "Error!",
                        Content = "Could not update your details,please try again later"
                    };
                    return View(model);
                }
            }
            return View(model);
        }


        //get the login page
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        // submit user login details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            // check if model valid
            if (ModelState.IsValid)
            {
                // find user using email address
                var user = await _userManager.FindByEmailAsync(model.Email);
                
                try
                {
                    // see if user and password match with the database content
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        model.Password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // redirect to main page if succeeded
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        // failed, wrong password
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                    }

                } catch (NullReferenceException nre)
                {
                    // exception shows that no user was found
                    ModelState.AddModelError("", "No username found");
                    return View(model);
                }
                    
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // get user registration form
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            Register model = new Register()
            {
                DateOfBirth = DateTime.Now
            };
            return View(model);
        }

        // get all the data from the registration form and create new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email", "FirstName", "CustomerRegistration", "Surname", "Name", "FLAddress", "SLAddress", "PostCode",
            "Password", "ConfirmPassword","PhoneNumber", "DateOfBirth")] Register model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            // if model valid
            if (ModelState.IsValid)
            {
                // create new user, no matter of the client type
                var newUser = new ApplicationUser()
                {
                    Address = model.FLAddress.Trim() + "," + model.SLAddress.Trim() + "," + model.PostCode.Trim(),
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);

                // user created successfully, adjust properties values based on user type
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
                        // try logging in the new user
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

        // check if account already exists
        private bool AccountExists(string id)
        {
            return _context.Users.Any(e => e.Id.Equals(id));
        }

        // http redirection
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