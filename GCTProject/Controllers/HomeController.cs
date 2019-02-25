using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCTProject.Models;
using Stripe;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using GCTProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using GCTProject.Models.ViewModels;
using AutoMapper;

namespace GCTProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _contextId;
        private readonly GCTProjectContext _contextData;

        public HomeController(
                    UserManager<IdentityUser> userManager,
                    ApplicationDbContext contextId,
                    GCTProjectContext context)
        {
            _userManager = userManager;
            _contextId = contextId;
            _contextData = context;
        }


        [AllowAnonymous]
        //GET Index/Home
        public async Task<IActionResult> Index()
        {
            var performances = await _contextData.Performance.Include(x => x.PerformanceDate).ToListAsync();
            foreach(var perform in performances)
            {
                foreach(var date in perform.PerformanceDate)
                {
                    if (date.Date < DateTime.Now)
                    {
                        _contextData.PerformanceDate.Remove(date);
                    }
                }
            }
            await _contextData.SaveChangesAsync();
            var filteredPerfs = await _contextData.Performance.Where(x => x.PerformanceDate.Any()).Include(x => x.Review).ToListAsync();
            int number = 1;
            int noOfPerf = filteredPerfs.Count();
            if (noOfPerf> 3)
            {
                number = noOfPerf / 3 + 1;
            }
            ViewData["Index"] = number;
            ViewData["NumberOfPerformances"] = noOfPerf;

            //List<DateTime> valueDates = new List<DateTime>();
            //for(int i = 0; i < performances.Count; i++)
            //{
            //    valueDates.Add(new DateTime());
            //}
            
            return View(filteredPerfs);
        }

        [AllowAnonymous]
        //display images for performances
        public ActionResult RenderPhoto(string photoId)
        {
            byte[] photo = (new GCTProjectContext()).Performance.Find(photoId).Picture;
            return File(photo, "image/jpeg");
        }

        //GET Privacy
        public IActionResult Privacy()
        {
            return View();
        }


        //Error report
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //URL redirection to local pages
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
    }
}
