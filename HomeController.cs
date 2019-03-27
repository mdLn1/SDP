using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCTOnlineServices.Models;
using GCTOnlineServices.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GCTOnlineServices.Models.OOPModels;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using GCTOnlineServices.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;

namespace GCTOnlineServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GCTContext _context;
        private readonly IMapper _mapper;
        private PlaysInfo playsInfo;
        private ClientInfo client;
        private TheatrePerformance currentPerformance;
        private GCTUser loggedInUser;
        private ClientBasket clientBasket;
        private List<TicketOrder> orders;

        private ITicketsToBuy _ticketsToBuy;

        // constructor, services are injected through constructors
        public HomeController(
                    UserManager<ApplicationUser> userManager,
                    GCTContext context,
                    IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            playsInfo = PlaysInfo.GetInstance();
            client = ClientInfo.GetInstance();
            _ticketsToBuy = TicketsToBuy.GetInstance();
        }

        #region Create Review or Play


        // HttpGet for Create View which initialises and prepares an instance of Theatreformance
        // user can add maximum 20 dates for a firstly created performance
        public IActionResult CreatePlay()
        {
            DateTime newDate = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
            PlayForCreation newPlay = new PlayForCreation();
            List<DateTime> dates = new List<DateTime>();

            for (int i = 0; i < 20; i++)
            {
                dates.Add(newDate);
            }
            newPlay.LiveDates = dates;


            return View(newPlay);
        }

        // HttpPost loads the previously initialised instance of performance with data received
        // from user input in the meanwhile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePlay(PlayForCreation newPlay, IFormFile file)
        {

            #region check if file uploaded

            var filePath = Path.GetTempFileName();


            if (file != null)
            {
                if (file.Length > 0)
                {
                    // use filestream to get the file from local to the controller
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            #endregion

            // proceed only if data inputted is valid
            if (ModelState.IsValid)
            {

                Play playCreated = new Play
                {
                    // prepare play for database
                    PriceStart = newPlay.PriceStart,
                    PriceEnd = newPlay.PriceEnd,
                    Name = newPlay.Name,
                    Description = newPlay.Description,
                    AgeRestriction = newPlay.AgeRestriction
                };

                // make use of Dispose functionality to make sure file data is removed 
                // once finished with it
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    #region Convert Data from TheatrePerformance to ERD Class Performance
                    playCreated.Picture = memoryStream.ToArray();

                    //add the new play to database
                    _context.Plays.Add(playCreated);

                    TheatrePlay theatrePlay = _mapper.Map<TheatrePlay>(playCreated);

                    //add new play to PlaysInfo Singleton
                    playsInfo.AddPlay(theatrePlay);

                    // for each valid date create an instance of performance
                    foreach (var perfDate in newPlay.LiveDates)
                    {
                        if (!perfDate.Date.Day.Equals(DateTime.Now.Day))
                        {
                            Performance performanceDate = new Performance()
                            {
                                Date = perfDate.Date,
                                PlayId = playCreated.Id
                            };
                            playCreated.Performances.Add(performanceDate);
                        }

                    }

                    // for each created performance create seating plan
                    foreach (var perfDate in playCreated.Performances)
                    {
                        foreach (var seat in _context.Seats)
                        {

                            BookedSeat booked = new BookedSeat()
                            {
                                SeatId = seat.Id,
                                Booked = 0
                            };
                            perfDate.BookedSeats.Add(booked);
                        }
                    }


                    #endregion

                    // save all the changes to the database
                    await _context.AddAsync(playCreated);
                    await _context.SaveChangesAsync();

                    // redirect to main page
                    return RedirectToAction(nameof(Index));
                }
            }

            // if program reached here something went wrong so return view to create performance
            return View(newPlay);
        }



        // Create a review
        public IActionResult CreateReview(int id)
        {
            return View();

        }

        // HttpPost create review
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("Comment")] Models.Review review)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                review.UserId = user.Id;
                review.UserName = user.UserName;
                review.Date = DateTime.Now;

                var play = await _context.Plays.FirstOrDefaultAsync(x => x.Id == playsInfo.GetCurrentPlay().Id);
                play.Reviews.Add(review);

                playsInfo.AddReview(review.PlayId,
                    _mapper.Map<PlayReview>(review));

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SelectDate), playsInfo.GetCurrentPlay().Id);
            }
            return View(review);
        }

        #endregion

        #region Delete Review or Play


        // HttpGet for deletion of a performance
        public async Task<IActionResult> DeletePlay(int? id)
        {
            //check if has id
            if (id == null)
            {
                return NotFound();
            }

            //find the performance
            var play = await _context.Plays
                .FirstOrDefaultAsync(m => m.Id == id);

            playsInfo.DeletePlay(play.Id);

            //check if found
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // confirmation of performance deletion
        [HttpPost, ActionName("DeletePlay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePlayConfirmed(int id)
        {
            var play = await _context.Plays.FindAsync(id);
            _context.Plays.Remove(play);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexPlays));
        }

        // display Delete page for the selected review
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Play)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // Review confirmed to be deleted
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReviewConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexReviews));
        }

        #endregion

        #region Display Details Review or Play

        // return all the details of the selected performance
        public async Task<IActionResult> DetailsPlay(int? id)
        {
            // check if id not null
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Plays
                .FirstOrDefaultAsync(m => m.Id == id);

            // check if performance found
            if (play == null)
            {
                return NotFound();
            }

            TheatrePlay theatrePlay = _mapper.Map<TheatrePlay>(play);

            return View(theatrePlay);
        }


        // display details of a review
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> DetailsReview(int? id)
        {
            // check if id assigned
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Play)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }


        #endregion

        #region Edit Play or Review

        // HttpGet request for editing the selected play
        public async Task<IActionResult> EditPlay(int? id)
        {
            //check if it has an id, if not send a 404 NotFound response
            if (id == null)
            {
                return NotFound();
            }

            // find the play in the database
            var playFound = await _context.Plays
                .Include(x => x.Performances).FirstOrDefaultAsync(x => x.Id == id);

            //check if playe found, if not send a 404 NotFound response
            if (playFound == null)
            {
                return NotFound();
            }

            // map it to an instance of TheatrePlay
            TheatrePlay play = _mapper.Map<TheatrePlay>(playFound);

            #region filter the dates 
            List<TheatrePerformance> dateTimes = new List<TheatrePerformance>();
            //if (performance.PerformanceDates.Any())
            //{
            //    foreach(var date in performance.PerformanceDates)
            //    {
            //        if (date.Date > DateTime.Now)
            //        {
            //            dateTimes.Add(_mapper.Map<LiveDate>(date));
            //        }

            //    }
            //    int addMoreSlots = dateTimes.Count + 20;
            //    int x = dateTimes.Count;
            //    while (x < addMoreSlots)
            //    {
            //        dateTimes.Add(new LiveDate() { Date = DateTime.Now });
            //    }
            //}
            //else
            //{
            //    for (int i =0; i < 20; i++)
            //    {
            //        dateTimes.Add(new LiveDate() { Date = DateTime.Now });
            //    }
            //}
            //perf.Dates = dateTimes;
            #endregion

            for (int i = 0; i < 20; i++)
            {
                dateTimes.Add(new TheatrePerformance() { Date = DateTime.Now });
            }
            play.Dates = dateTimes;
            return View(play);
        }


        // HttpPost receive the play that was to be edited with the new content
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerformance(int Id, TheatrePlay play)
        {
            // check if Ids match, if not return 404 Not Found Exception
            if (Id != play.Id)
            {
                return NotFound();
            }

            // find play to edit
            var perfEdit = await _context.Plays.Include(x => x.Performances)
                .FirstOrDefaultAsync(x => x.Id == play.Id);

            // check model
            if (ModelState.IsValid)
            {
                // add new date fields, check if date was changed and 
                // it is in the future, starting from the day after
                foreach (var date in play.Dates)
                {
                    if (!date.Date.Day.Equals(DateTime.Now.Day))
                    {
                        Performance performanceDate = new Performance()
                        {
                            Date = date.Date,
                            PlayId = play.Id

                        };

                    }

                }

                // create booked seats for each date and set them as not booked
                foreach (var perfDate in perfEdit.Performances)
                {
                    foreach (var seat in _context.Seats)
                    {

                        BookedSeat booked = new BookedSeat()
                        {
                            SeatId = seat.Id,
                            Booked = 0
                        };
                        perfDate.BookedSeats.Add(booked);
                    }
                }
                perfEdit.Name = play.Name;
                perfEdit.Description = play.Description;
                perfEdit.AgeRestriction = play.AgeRestriction.ToString();

                await _context.SaveChangesAsync();
                try
                {
                    _context.Update(perfEdit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayExists(play.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexPlays));
            }
            return View(play);
        }



        // Edit a review allowed by higher authority
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        public async Task<IActionResult> EditReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["PerformanceId"] = new SelectList(_context.Plays, "Id",
                "Id", review.PlayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            return View(review);
        }

        // submit changes to the edited review
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id,PerformanceId,UserId,UserName" +
            ",Comment,Date")] Models.Review review)
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
                return RedirectToAction(nameof(IndexReviews));
            }
            ViewData["PerformanceId"] = new SelectList(_context.Plays, "Id", "Id", review.PlayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            return View(review);
        }


        #endregion

        #region Indexes (display Plays/Reviews/Orders/Main Page)


        [AllowAnonymous]
        // the Home Page of the website
        // it shows all the available performances to the user
        public async Task<IActionResult> Index()
        {
            // fetch performances with all related data from database
            var availableDates = await _context
                .Performances.Where(x => x.Date > DateTime.Now).ToListAsync();

            var plays = await _context.Plays.ToListAsync();

            var user = await _userManager.GetUserAsync(User);

            if (client.GetLoggedInUser() == null && user != null)
            {
                var role = await _userManager.GetRolesAsync(user);

                client.SetUser(user, role[0]);
            }

            if (plays != null)
            {
                playsInfo.DeleteAllPlays();
            }
                // assign data received to the list of theatrePerformances
                foreach (var play in plays)
                {
                    TheatrePlay newPlay = new TheatrePlay();
                    newPlay = _mapper.Map<TheatrePlay>(play);
                    if (newPlay.Description.Length > 100)
                    {
                        newPlay.Description = newPlay.Description.Substring(0, 100) + "...";
                    }
                    newPlay.Dates = _mapper.Map<IEnumerable<TheatrePerformance>>
                        (availableDates.Where(x => x.PlayId == play.Id)).ToList();
                    newPlay.Reviews = _mapper.Map<IEnumerable<PlayReview>>(play.Reviews).ToList();

                    playsInfo.AddPlay(newPlay);
                }

            // if there are no available dates in the future for plays then show empty page
            if (availableDates == null)
            {
                return View();
            }

            // filter data for view
            int number = 1;
            int noOfPlays = plays.Count();
            if (noOfPlays > 3)
            {
                number = noOfPlays / 3 + 1;
            }
            ViewData["Index"] = number;
            ViewData["NumberOfPerformances"] = noOfPlays;


            return View(playsInfo.GetPlays());
        }

        // get all the orders for a specific client
        public async Task<IActionResult> IndexOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _context.Orders.Where(x => x.UserId == user.Id).ToListAsync();

            return View(orders);
        }

        // get all the orders for a specific client
        public async Task<IActionResult> OrderedTickets(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(IndexOrders));
            }

            var user = await _userManager.GetUserAsync(User);
            var tickets = await _context.SoldTickets.Where(x => x.OrderId == id).ToListAsync();

            return View(tickets);
        }

        // return all the performances, admin view
        public IActionResult IndexPlays()
        {
            return View(playsInfo.GetPlays());
        }


        // Display all the review for the selected performance
        [AllowAnonymous]
        public async Task<IActionResult> IndexReviews(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // find selected performance in database
            var play = await _context.Plays.Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (play != null)
            {
                return NotFound();
            }

            @ViewData["PerformanceName"] = play.Name;
            @ViewData["PerformanceDescription"] = play.Description;
            @ViewData["PerformanceId"] = play.Id;

            // no reviews, display view
            if (!play.Reviews.Any())
                return View();

            // set the performance if found
            TheatrePlay playSelected = _mapper.Map<TheatrePlay>(play);

            // look into the performances if it exists
            foreach (TheatrePlay perf in playsInfo.GetPlays())
            {
                if (perf.Id == Id)
                {
                    playSelected = perf;
                    break;
                }
            }

            playsInfo.SetCurrentPlay(playSelected);

            //var gCTProjectContext = _context.Reviews.Where(x => x.PerformanceId == Id).Include(r => r.Performance).Include(r => r.User);

            //return View(await gCTProjectContext.ToListAsync());

            return View(playSelected.Reviews);
        }

        #endregion

        #region Check if Entity Exists


        //Checks if performance exists
        private bool PlayExists(int id)
        {
            return _context.Plays.Any(e => e.Id == id);
        }


        // check review exists
        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }

        #endregion

        #region Helpers 

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


        [AllowAnonymous]
        // return the photo of the performances
        public ActionResult RenderPhoto(int photoId)
        {
            byte[] photo = _context.Plays.Find(photoId).Picture;
            return File(photo, "image/jpeg");
        }

        #endregion


        // return privacy policy view
        public IActionResult Privacy()
        {
            return View();
        }


        #region Client Basket related actions

        // return the content of user's basket
        public async Task<IActionResult> Basket()
        {
            var user = await _userManager.GetUserAsync(User);

            var basketTickets = _context.BasketTickets.Where(bt => bt.UserId == user.Id);

            if (basketTickets != null)
            {

                var savedRepresentations = new List<TicketsInBasket>();
                decimal totalCost = 0;

                foreach (var item in basketTickets)
                {
                    var chosenSeat = await _context.BookedSeats.Include(x => x.Performance)
                        .Include(y => y.Seat).FirstOrDefaultAsync(z => z.Id == item.BookedSeatId);
                    var play = await _context.Plays
                        .FirstOrDefaultAsync(x => x.Id == chosenSeat.Performance.PlayId);
                    var tb = new TicketsInBasket
                    {
                        Id = item.BookedSeatId
                    };
                    decimal[] prices = { play.PriceStart, play.PriceEnd };
                    //decimal col = decimal.Parse(chosenSeat.Seat.ColumnNumber);
                    //if (col < 13)
                    //{
                    //    tb.Cost = prices[0];
                    //}else if (col < 19)
                    //{
                    //    tb.Cost = (prices[0] + prices[1]) / 2;
                    //}
                    //else
                    //{
                    //    tb.Cost = prices[1];
                    //}

                    totalCost += tb.Cost;
                    tb.RowNumber = chosenSeat.Seat.RowNumber;
                    //b.SeatLetter = col.ToString();
                    tb.PerformanceName = play.Name;
                    tb.PerformanceTime = chosenSeat.Performance.Date;
                    savedRepresentations.Add(tb);
                }
                var basket = await _context.Basket.FirstOrDefaultAsync(x => x.UserId == user.Id);




                ClientBasket userBasket = new ClientBasket
                {
                    ShippingMethod = basket.ShippingMethod,
                    Tickets = _mapper.Map<IEnumerable<TicketForBasket>>(savedRepresentations).ToList()
                };

                ViewBag.tickets = savedRepresentations;
                ViewBag.TotalCost = totalCost;
                ViewBag.Delivery = userBasket.ShippingMethod;

                return View();
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.BasketTickets.FirstOrDefaultAsync(m => m.BookedSeatId == id);
            _context.BasketTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Basket));
        }


        [HttpGet]
        public async Task<string> AddToBasket(string savedSeats)
        {
            

            if (savedSeats != "" && savedSeats != null)
            {
                List<TheatreSeat> seats = _ticketsToBuy.GetSelectedSeats();
                _ticketsToBuy.RemoveAllSelectedSeats();

                List<string> rows = new List<string>();
                List<int> chairNumbers = new List<int>();
                var user = await _userManager.GetUserAsync(User);
               // var basketTickets =  await _context.Ba
                foreach (TheatreSeat seat in seats)
                {
                    await _context.BasketTickets
                        .AddAsync(new BasketTicket() { UserId = user.Id, BookedSeatId = seat.Id,
                            PerformanceId = playsInfo.GetCurrentPerformance().PerformanceId, Price = seat.Price });

                }

                await _context.SaveChangesAsync();
                return "Ok";

            }
            return "NotOk";

        }

        #endregion


        #region Booking process related Actions
        [AllowAnonymous]
        // return view to allow user to pick a date
        public IActionResult SelectDate(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var play = _context.Plays.Include(x => x.Performances).Include(x => x.Reviews)
                .FirstOrDefault(x => x.Id == Id);

            var foundDates = play.Performances.Where(x => x.Date > DateTime.Now).OrderBy(x => x.Date).ToList();

            TheatrePlay currentPlay = _mapper.Map<TheatrePlay>(play);
            currentPlay.Dates = new List<TheatrePerformance>();
            currentPlay.Reviews = new List<PlayReview>();

            foreach (var date in foundDates)
                currentPlay.Dates.Add(_mapper.Map<TheatrePerformance>(date));

            foreach (var review in play.Reviews)
                currentPlay.Reviews.Add(_mapper.Map<PlayReview>(review));

            playsInfo.SetCurrentPlay(currentPlay);

            return View(currentPlay);
        }

        [HttpGet]
        public async Task<IActionResult> BuyNow(string SavedSeats, decimal Total, string stripeToken, bool RememberMe, string customerName)
        {
            List<TheatreSeat> seats = _ticketsToBuy.GetSelectedSeats(); ;
            var user = await _userManager.GetUserAsync(User);
            var basket = await _context.Basket.FirstOrDefaultAsync(x => x.UserId == user.Id);

            if (SavedSeats != "" && Total > 0)
            {
                long amount = long.Parse(Total.ToString("#.00").Replace(".", ""));
                if (amount < 100)
                {
                    amount *= 100;
                }

                if (Charge(user.Email, stripeToken, amount, RememberMe))
                {

                    Models.Order newOrder = new Models.Order()
                    {
                        OrderTime = DateTime.Now,
                        PlayName = playsInfo.GetCurrentPlay().Name,
                        UserId = user.Id,
                        DeliveryMethod = basket.ShippingMethod
                        
                    };

                    if (client.GetUserRole() != "Customer" && client.GetUserRole() != "AgencyOrClub")
                    {

                        newOrder.ClientName = user.FirstName + " " + user.LastName;
                    }
                    else
                    {
                        newOrder.ClientName = customerName;
                    }
                    DateTime time = DateTime.Now;
                    bool discount = false;
                    if (((int)time.DayOfWeek < 5) && ((int)time.DayOfWeek > 0))
                    {
                        discount = true;

                    }
                    foreach (TheatreSeat seatBooked in seats)
                    {
                        SoldTicket soldTicket = _mapper.Map<SoldTicket>(seatBooked);
                        soldTicket.PlayName = playsInfo.GetCurrentPlay().Name;
                        soldTicket.UserId = user.Id;
                        soldTicket.CustomerName = newOrder.ClientName;
                        soldTicket.PerformanceTimeAndDate = playsInfo.GetCurrentPerformance().Date;
                        if (discount)
                        {
                            soldTicket.PaidPrice = seatBooked.ReducedPrice;
                        }
                        else
                        {
                            soldTicket.PaidPrice = seatBooked.Price;
                        }
                        newOrder.SoldTickets.Add(soldTicket);
                    }

                    await _context.Orders.AddAsync(newOrder);
                    
                    foreach (TheatreSeat seat in seats)
                    {
                        var bookedSeat = await _context.BookedSeats
                            .FirstOrDefaultAsync(x => x.Id == seat.Id);
                        
                        bookedSeat.Booked = 2;
                        _context.Update(bookedSeat);

                    }
                    await _context.SaveChangesAsync();

                    TicketAndReceipt ticketAndReceipt = new TicketAndReceipt()
                    {
                        Date = playsInfo.GetCurrentPerformance().Date,
                        PlayName = playsInfo.GetCurrentPlay().Name,
                        TotalCost = Total,
                        PersonName = newOrder.ClientName,
                        Tickets = seats
                    };
                    _ticketsToBuy.RemoveAllSelectedSeats();
                    return View(ticketAndReceipt);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Seating(string DateSelected = null, string Id = null)
        {
            ViewBag.Date = DateTime.Now.AddMinutes(5);

            

            if (Id == null)
            {
                return View();
            }


            List<string> parames = new List<string>
            {
                Id,
                DateSelected
            };

            var perfDate = _context.Performances.Include(x => x.Play)
                .Include(x => x.BookedSeats).ThenInclude(x => x.Seat).FirstOrDefault(x => x.Date == DateTime.Parse(parames.ElementAt(1)));

            playsInfo.SetCurrentPerformance(new TheatrePerformance()
            { PerformanceId = perfDate.Id, Date = DateTime.Parse(DateSelected) });

            IQueryable<string> rowNames = from r in _context.Seats
                                       orderby r.Band
                                       select r.Band.Trim();

            List<string> rows = await rowNames.Distinct().ToListAsync();
            for (int i = 0; i < rows.Count; i++)
            {
                rows[i] = rows.ElementAt(i);
            }

            bool discount = false;
            DateTime time = DateTime.Now;
            if (((int)time.DayOfWeek < 5) && ((int)time.DayOfWeek > 0))
            {
                discount = true;

            }
            decimal endPrice = perfDate.Play.PriceStart;
            decimal startPrice = perfDate.Play.PriceEnd;

            List<decimal> costs = new List<decimal>();

            if (discount)
            {
                startPrice = (8 * startPrice) / 10;
                endPrice = (8 * endPrice) / 10;
            }


            costs.Add(decimal.Parse(startPrice.ToString("0.00")));
            costs.Add(decimal.Parse(((startPrice + endPrice) / 2).ToString("0.00")));
            costs.Add(decimal.Parse(endPrice.ToString("0.00")));

            var user = await _userManager.GetUserAsync(User);

            DisplaySeating newTicket = new DisplaySeating()
            {
                SelectedDate = DateTime.Parse(parames.ElementAt(1)),
                BookedSeats = perfDate.BookedSeats.OrderBy(x => x.Seat.SeatNumber).ToList(),
                RowNames = rows,
                Costs = costs,
                DiscountApplied = discount,
                DiscountedPrices = startPrice + "-" + endPrice,
                PriceBand = perfDate.Play.PriceStart + "-" + perfDate.Play.PriceEnd,
                Total = 0,
                SavedSeats = "",
                RememberMe = false
            };

            return View(newTicket);
        }

        [HttpGet]
        public IActionResult GiveTicketAndReceipt()
        {

            return View();
        }

        // require a seat to be added to tickets to buy
        [HttpGet]
        public async Task<ActionResult> ReserveSeat(int id, decimal price)
        {
            bool discount = false;
            TheatreSeat newSeat = new TheatreSeat();

            DateTime time = DateTime.Now;
            if (((int)time.DayOfWeek < 5) && ((int)time.DayOfWeek > 0))
            {
                discount = true;

            }
            if(discount)
            {
                newSeat.Price = price * 10 / 8;
                newSeat.ReducedPrice = price;
            } else
            {
                newSeat.Price = price;
            }

            var seat = await _context.BookedSeats.Include(x => x.Seat).FirstOrDefaultAsync(x => x.Id == id);
            if (seat.Booked != 2)
            {
                seat.ExpiryTime = DateTime.Now.AddMinutes(5);
                seat.Booked = 1;

                newSeat.Booked = seat.Booked;
                newSeat.ColumnLetter = seat.Seat.ColumnLetter;
                newSeat.Id = seat.Id;
                newSeat.RowNumber = seat.Seat.RowNumber;
                newSeat.Band = seat.Seat.Band;

                _ticketsToBuy.AddSeat(newSeat);

                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
            }

            BookSeatResult bookSeatResult = new BookSeatResult()
            {
                Number = id,
                Result = "finished successfully"

            };
            return Json(bookSeatResult);
        }

        //GET Charge/Booking
        public bool Charge(string stripeEmail, string stripeToken, long amount, bool RememberMe)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();



            if (RememberMe)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == stripeEmail);
                var customer = customers.Create(new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    SourceToken = stripeToken
                });
                // Charge the Customer instead of the card:
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = 1000,
                    Currency = "gbp",
                    Description = "Theatre charge",
                    CustomerId = customer.Id,
                };
                var chargeService = new ChargeService();
                Charge charge = chargeService.Create(chargeOptions);
                if (charge.Status.ToLower() == "succeeded")
                {
                    user.SavedCustomerCard = customer.Id;
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                var charge = charges.Create(new ChargeCreateOptions
                {
                    Amount = amount,
                    Description = "Theatre charge",
                    Currency = "gbp",
                    SourceId = stripeToken
                });

                if (charge.Status.ToLower() == "succeeded")
                {
                    return true;
                }
            }
            return false;
        }


        #endregion



    }
}
