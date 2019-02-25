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
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using System.Dynamic;

namespace GCTProject.Controllers
{
    [Authorize(Roles = "Manager,Admin,SalesStaff")]
    public class PerformancesController : Controller
    {
        private readonly GCTProjectContext _context;

        public PerformancesController(GCTProjectContext context)
        {
            _context = context;
        }

        // GET: Performances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Performance.ToListAsync());
        }

        // GET: Performances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performance = await _context.Performance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performance == null)
            {
                return NotFound();
            }

            return View(performance);
        }

        //GET multipel files upload, not in use
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }


        //Get Photo for performance
        public ActionResult RenderPhoto(string photoId)
        {
            byte[] photo = (new GCTProjectContext()).Performance.Find(photoId).Picture;
            return File(photo, "image/jpeg");
        }



        // GET: Performances/Create
        public IActionResult Create()
        {
            DateTime newDate = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
            PerformanceCreation newPerf = new PerformanceCreation();
            List<DateTime> dates = new List<DateTime>();
           
            for (int i = 0; i < 20; i++)
            {
                dates.Add(newDate);
            }
            newPerf.LiveDates = dates;

            return View(newPerf);
        }

        // POST: Performances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind("PriceBand,LiveDates,Name,Description,AgeRestriction,Picture")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PerformanceCreation performanceCreation, IFormFile file)
        {
            Performance performance = new Performance();

            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if (ModelState.IsValid)
            {
                performance.Id = Guid.NewGuid().ToString();
                performance.PriceBand = performanceCreation.PriceStart + "-" + performanceCreation.PriceEnd;
                performance.Name = performanceCreation.Name;
                performance.Description = performanceCreation.Description;
                performance.AgeRestriction = performanceCreation.AgeRestriction.ToString();


                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    performance.Picture = memoryStream.ToArray();


                    foreach (var date in performanceCreation.LiveDates)
                    {
                        if (!date.Day.Equals(DateTime.Now.Day))
                        {
                            PerformanceDate performanceDate = new PerformanceDate()
                            {
                                Date = date,
                                PerformanceId = performance.Id
                            };
                            performance.PerformanceDate.Add(performanceDate);
                        }

                    }
                    foreach (var perfDate in performance.PerformanceDate)
                    {
                        foreach (var seat in _context.Seats)
                        {

                            BookedSeats booked = new BookedSeats()
                            {
                                Seatid = seat.Id,
                                Booked = 0
                            };
                            perfDate.BookedSeats.Add(booked);
                        }
                    }

                    await _context.AddAsync(performance);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(performance);
        }

        //Post Upload, no longer used
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok();
        }

        // GET: Performances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PerformanceEdit perf = new PerformanceEdit();
            var performance = await _context.Performance.FirstOrDefaultAsync(x => x.Id == id);
            var dates = _context.PerformanceDate.Where(x => x.PerformanceId == performance.Id);
            List<DateTime> dateTimes = new List<DateTime>();
            if (await dates.AnyAsync())
            {
                foreach(var date in dates)
                {
                    dateTimes.Add(date.Date);
                }
                if (dateTimes.Count < 20)
                {
                    while(dateTimes.Count < 20)
                    {
                        dateTimes.Add(DateTime.Now);
                    }
                }
            }
            else
            {
                for (int i =0; i < 20; i++)
                {
                    dateTimes.Add(DateTime.Now);
                }
            }
            perf.Description = performance.Description;
            perf.Id = performance.Id;
            perf.Picture = performance.Picture;
            perf.PriceStart = decimal.Parse(performance.PriceBand.Split("-").ElementAt(0));
            perf.PriceEnd = decimal.Parse(performance.PriceBand.Split("-").ElementAt(1));
            perf.Name = performance.Name;
            perf.LiveDates = dateTimes;

            if (performance == null)
            {
                return NotFound();
            }
            return View(perf);
        }

        // POST: Performances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LiveDate,Name,Description,AgeRestriction,Picture")] PerformanceEdit performance)
        {
            if (id != performance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceExists(performance.Id))
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
            return View(performance);
        }

        // GET: Performances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performance = await _context.Performance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performance == null)
            {
                return NotFound();
            }

            return View(performance);
        }

        // POST: Performances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var performance = await _context.Performance.FindAsync(id);
            _context.Performance.Remove(performance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Checks if performance exists
        private bool PerformanceExists(string id)
        {
            return _context.Performance.Any(e => e.Id == id);
        }
    }
}
