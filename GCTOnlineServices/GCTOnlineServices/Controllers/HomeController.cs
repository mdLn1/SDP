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
        private TicketsToBuy _ticketsToBuy;

        // constructor, services are injected through constructors
        public HomeController(
                    UserManager<ApplicationUser> userManager,
                    GCTContext context,
                    IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _ticketsToBuy = TicketsToBuy.GetInstance();
        }

        #region Create Review or Play

        // done
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

        // done
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


        //done
        // Create a review
        public IActionResult CreateReview(int id)
        {
            Models.Review review = new Models.Review()
            {
                PlayId = id
            };
            return View(review);

        }

        // done
        // HttpPost create review and add it to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("PlayId, Comment")] Models.Review review)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                review.UserId = user.Id;
                review.UserName = user.UserName;
                review.Date = DateTime.Now;

                var play = await _context.Plays.FirstOrDefaultAsync(x => x.Id == review.PlayId);
                play.Reviews.Add(review);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SelectDate), review.PlayId);
            }
            return View(review);
        }

        #endregion

        #region Delete Review or Play

        // done
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

            //check if found
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // done
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

        // done
        // display Delete page for the selected review
        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var review = await _context.Reviews.Include(x => x.Play).FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            

            return View(review);
        }

        // done
        // Review confirmed to be deleted
        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReviewConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Display Details Review or Play
        // 
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

            // check if play found
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
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
        //done
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
            int count = 0;
            PerformanceEdit performanceEdit = _mapper.Map<PerformanceEdit>(playFound);

            while (count < 21)
            {
                count++;
                performanceEdit.LiveDates.Add(DateTime.Now);
            }

            return View(performanceEdit);
        }

        // done
        // HttpPost receive the play that was to be edited with the new content
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlay(int Id, PerformanceEdit play)
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
                foreach (var date in play.LiveDates)
                {
                    if (!date.Date.Day.Equals(DateTime.Now.Day))
                    {
                        Performance performanceDate = new Performance()
                        {
                            Date = date.Date,
                            PlayId = play.Id

                        };
                        // create booked seats for each date and set them as not booked
                        foreach (var seat in _context.Seats)
                        {

                            BookedSeat booked = new BookedSeat()
                            {
                                SeatId = seat.Id,
                                Booked = 0
                            };
                            performanceDate.BookedSeats.Add(booked);
                        }
                        perfEdit.Performances.Add(performanceDate);
                    }

                }
                
                perfEdit.Name = play.Name;
                perfEdit.Description = play.Description;
                perfEdit.AgeRestriction = play.AgeRestriction.ToString();
                // try update database
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


        // done
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

        // done
        // submit changes to the edited review
        [Authorize(Roles = "Manager,Admin,SalesStaff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id,Comment,Date")] Models.Review review)
        {
            // check the rigth review
            if (id != review.Id)
            {
                return NotFound();
            }

            // check new review valid
            if (ModelState.IsValid)
            {
                try
                {   //update review
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // check if the review exists
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SelectDate), review.PlayId);
            }
            ViewData["PerformanceId"] = new SelectList(_context.Plays, "Id", "Id", review.PlayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            return View(review);
        }


        #endregion

        #region Indexes (display Plays/Orders/Main Page)


        [AllowAnonymous]
        // the Home Page of the website
        // it shows all the available performances to the user
        public async Task<IActionResult> Index()
        {
            // fetch performances with all related data from database
            var plays = await _context.Plays.ToListAsync();

            // filter data for view
            int number = 1;
            int noOfPlays = plays.Count();
            if (noOfPlays > 3)
            {
                number = noOfPlays / 3 + 1;
            }
            ViewData["Index"] = number;
            ViewData["NumberOfPerformances"] = noOfPlays;

            return View(plays);
        }

        // done
        // get all the orders for a specific client
        public async Task<IActionResult> IndexOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _context.Orders.Where(x => x.UserId == user.Id).ToListAsync();

            return View(orders);
        }

        // done
        // get all the sold tickets for a specific order
        public async Task<IActionResult> OrderedTickets(int? id)
        {
            // check id id not null
            if (id == null)
            {
                return RedirectToAction(nameof(IndexOrders));
            }

            // get the tickets sold in the specific order
            var tickets = await _context.SoldTickets.Where(x => x.OrderId == id).ToListAsync();

            return View(tickets);
        }

        // done
        // return all the plays, admin/sales staff view
        public async Task<IActionResult> IndexPlays()
        {
            return View(await _context.Plays.ToListAsync());
        }

        #endregion

        #region Check if Entity Exists


        //Checks if play exists
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

        [AllowAnonymous]
        // return privacy policy view
        public IActionResult Privacy()
        {
            return View();
        }


        #region Client Basket related actions

        // done
        // return the content of user's basket
        public async Task<IActionResult> Basket()
        {
            var user = await _userManager.GetUserAsync(User);

            var basketTickets = _context.BasketTickets.Include(x => x.Performance).ThenInclude(y => y.Play)
                .Include(x => x.BookedSeat).ThenInclude(y => y.Seat).Where(bt => bt.UserId == user.Id);
            var basket = await _context.Basket.FindAsync(user.Id);
            ViewBasket viewBasket = new ViewBasket();
            viewBasket.DeliveryMethod = new List<string>();
            viewBasket.tickets = new List<TicketsInBasket>();

            viewBasket.DeliveryMethod.Add("Pick from collection booth");

            if (basketTickets != null)
            {
                
                foreach (var item in basketTickets)
                {
                    TicketsInBasket ticket = new TicketsInBasket
                    {
                        Price = item.Price,
                        RowNumber = item.BookedSeat.Seat.RowNumber,
                        SeatLetter = item.BookedSeat.Seat.ColumnLetter,
                        PerformanceName = item.Performance.Play.Name,
                        Id = item.Id,
                        PerformanceTime = item.Performance.Date
                    };
                    viewBasket.Total += item.Price;
                    viewBasket.tickets.Add(ticket);
                }
                viewBasket.DeliveryMethod.Add(basket.ShippingMethod);
                return View(viewBasket);
            }

            return View(viewBasket);
        }

        // done
        // remove ticket
        [HttpGet]
        public async Task<IActionResult> DeleteTicket(int? id)
        {

            var ticket = await _context.BasketTickets.FirstOrDefaultAsync(m => m.BookedSeatId == id);
            _context.BasketTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Basket));
        }
        // done
        // add selected seats to basket as tikets
        [HttpGet]
        public async Task<IActionResult> AddToBasket(string savedSeats)
        {

            if (savedSeats != "" && savedSeats != null)
            {
                // get the selected seats
                List<TheatreSeat> seats = _ticketsToBuy.GetSelectedSeats();
                var performance = await _context.BookedSeats.FirstOrDefaultAsync(x => x.Id == seats[0].Id);
                var user = await _userManager.GetUserAsync(User);
                foreach (TheatreSeat seat in seats)
                {
                    //add each ticket to basket
                    await _context.BasketTickets
                        .AddAsync(new BasketTicket() { UserId = user.Id, BookedSeatId = seat.Id,
                            PerformanceId = performance.PerformanceId, Price = seat.Price });

                }

                _ticketsToBuy.RemoveAllSelectedSeats();
                // save changes
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Basket));

            }
            return RedirectToAction(nameof(Index));

        }

        #endregion


        #region Booking process related Actions

        [AllowAnonymous]
        //done
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
            currentPlay.Performances = foundDates;
            currentPlay.Reviews = play.Reviews.ToList();

            return View(currentPlay);
        }

        [HttpPost]
        // done
        // basket checkout
        public async Task<IActionResult> BuyNow(ViewBasket basketView,string stripeToken, bool RememberMe, string customerName)
        {
            var user = await _userManager.GetUserAsync(User);
            var role = await _userManager.GetRolesAsync(user);
            var tickets = await _context.BasketTickets
                .Include(x => x.BookedSeat).ThenInclude(y => y.Seat).Where(x => x.UserId == user.Id).ToListAsync();
            // check if any seats
            if (tickets.Count > 0 && user.Basket.TotalPrice > 0)
            {
                long amount = long.Parse(user.Basket.TotalPrice.ToString("#.00").Replace(".", ""));
                if (amount < 100)
                {
                    amount *= 100;
                }

                if (Charge(user.Email, stripeToken, amount, RememberMe))
                {
                    // charge succeeded, create an order
                    Models.Order newOrder = new Models.Order()
                    {
                        OrderTime = DateTime.Now,
                        UserId = user.Id,
                        DeliveryMethod = user.Basket.ShippingMethod
                        
                    };

                    // check who is the customer
                    if (role[0] == "Customer")
                    {

                        newOrder.ClientName = user.FirstName + " " + user.LastName;
                    } else if (role[0] == "AgencyOrClub") {
                        newOrder.ClientName = user.AgencyOrClubName;
                    }
                    else
                    {
                        newOrder.ClientName = customerName;
                    }

                    // see if there was a discount
                    DateTime time = DateTime.Now;
                    bool discount = false;
                    if (((int)time.DayOfWeek < 5) && ((int)time.DayOfWeek > 0))
                    {
                        discount = true;

                    }
                    // create a sold ticket for each seat reserved
                    foreach (TicketsInBasket seatBooked in basketView.tickets)
                    {
                        SoldTicket soldTicket = _mapper.Map<SoldTicket>(seatBooked);
                        soldTicket.PlayName = seatBooked.PerformanceName;
                        soldTicket.UserId = user.Id;
                        soldTicket.CustomerName = newOrder.ClientName;
                        soldTicket.PerformanceTimeAndDate = seatBooked.PerformanceTime;
                        if (discount)
                        {
                            soldTicket.PaidPrice = seatBooked.Price;
                            //soldTicket.PaidPrice = seatBooked.ReducedPrice;
                        }
                        else
                        {
                            soldTicket.PaidPrice = seatBooked.Price;
                        }
                        newOrder.SoldTickets.Add(soldTicket);
                    }

                    decimal finalPrice = 0;

                    // add order to database
                    await _context.Orders.AddAsync(newOrder);
                    
                    foreach (TicketsInBasket seat in basketView.tickets)
                    {
                        var bookedSeat = await _context.BookedSeats
                            .FirstOrDefaultAsync(x => x.Id == seat.Id);
                        if (discount)
                        {
                            finalPrice += seat.Price;
                        }
                        bookedSeat.Booked = 2;
                        _context.Update(bookedSeat);

                    }
                    await _context.SaveChangesAsync();
                    

                    // cereate tickets and receipt view
                    TicketAndReceipt ticketAndReceipt = new TicketAndReceipt()
                    {
                        TotalCost = basketView.Total,
                        PersonName = newOrder.ClientName,
                        Tickets = basketView.tickets,
                        DiscountApplied = discount,
                        Saved = 0
                    };

                    if (discount)
                    {
                        ticketAndReceipt.Saved = basketView.Total - finalPrice;
                    }

                    return View(ticketAndReceipt);
                }
            }
            return View();
        }

        // done
        //get the seating plan for the specified performance
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
                .Include(x => x.BookedSeats).ThenInclude(x => x.Seat)
                .FirstOrDefault(x => x.Date == DateTime.Parse(DateSelected));

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
            _ticketsToBuy.RemoveAllSelectedSeats();

            return View(newTicket);
        }

        // done
        // require a seat to be added to tickets to buy
        [HttpGet]
        public async Task<ActionResult> ReserveSeat(int id, decimal price)
        {
            // check if there was a discount
            bool discount = false;
            TheatreSeat newSeat = new TheatreSeat();
            List<TheatreSeat> savedSeats = _ticketsToBuy.GetSelectedSeats();

            BookSeatResult bookSeatResult = new BookSeatResult()
            {
                Number = id
            };

            // look if seat already added, if yes remove it
            foreach (TheatreSeat savedSeat in savedSeats)
            {
                if (savedSeat.Id == id)
                {
                    _ticketsToBuy.DeleteSeat(id);
                    bookSeatResult.Result = "unsuccesful";
                    
                    return Json(bookSeatResult);
                }
            }

            // handle pricing if discoun is to be applied
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

            //find the seat and check if not already booked
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

                // set a temporary lock on the seat
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
            }

            bookSeatResult.Result = "finished successfully";
            return Json(bookSeatResult);
        }

        // done
        // try charging the customer, return true if it worked
        public bool Charge(string stripeEmail, string stripeToken, long amount, bool RememberMe)
        {
            // using stripe API library
            var customers = new CustomerService();
            var charges = new ChargeService();

            // check if customer wants to save their details
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

                // if charge succeeded add customer id to saved card for future payment
                if (charge.Status.ToLower() == "succeeded")
                {
                    user.SavedCustomerCard = customer.Id;
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                // simply charge customer
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
