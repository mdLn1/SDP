using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCTProject.Data;
using GCTProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace GCTProject.Controllers
{
    
    public class BookingController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _contextId;
        private readonly GCTProjectContext _contextData;

        public BookingController(
                    UserManager<IdentityUser> userManager,
                    ApplicationDbContext contextId,
                    GCTProjectContext context)
        {
            _userManager = userManager;
            _contextId = contextId;
            _contextData = context;
        }

        //GET Basket/Booking
        public async Task<IActionResult> Basket()
        {
            var user = await _userManager.GetUserAsync(User);
            
            var basketTickets = _contextData.BasketTickets.Where(bt => bt.UserId == user.Id);

            if (basketTickets != null)
            {

                var savedRepresentations = new List<TicketsInBasket>();
                decimal totalCost = 0;
               
                foreach (var item in basketTickets)
                {
                    var chosenSeat = await _contextData.BookedSeats.Include(x => x.PerformanceDate).Include(y => y.Seat).FirstOrDefaultAsync(z => z.Id == item.BookedSeatId);
                    var performance = await _contextData.Performance.FirstOrDefaultAsync(x => x.Id == chosenSeat.PerformanceDate.PerformanceId);
                    var tb = new TicketsInBasket();
                    tb.Id = item.BookedSeatId;
                    string[] prices = performance.PriceBand.Split('-');
                    decimal col = decimal.Parse(chosenSeat.Seat.ColumnNumber);
                    if (col < 13)
                    {
                        tb.Cost = decimal.Parse(prices[0]);
                    }else if (col < 19)
                    {
                        tb.Cost = (decimal.Parse(prices[0]) + decimal.Parse(prices[1])) / 2;
                    }
                    else
                    {
                        tb.Cost = decimal.Parse(prices[1]);
                    }
                    
                    totalCost += tb.Cost;
                    tb.RowNumber = chosenSeat.Seat.RowName;
                    tb.SeatNumber = col.ToString();
                    tb.PerformanceName = performance.Name;
                    tb.PerformanceTime = chosenSeat.PerformanceDate.Date;
                    savedRepresentations.Add(tb);
                }
                var basket = await _contextData.Basket.FirstOrDefaultAsync(x => x.UserId == user.Id);
                ViewBag.tickets = savedRepresentations;
                ViewBag.TotalCost = totalCost;
                ViewBag.Delivery = basket.ShippingMethod;
                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<string> AddToBasket(string savedSeats)
        {
            List<int> seats = new List<int>();

            if (savedSeats != "" && savedSeats != null)
            {
                savedSeats = savedSeats.TrimEnd();
                var receivedSeats = savedSeats.Split(" ");
                foreach (string el in receivedSeats)
                {
                    seats.Add(int.Parse(el));
                }
                List<string> rows = new List<string>();
                List<int> chairNumbers = new List<int>();
                var user = await _userManager.GetUserAsync(User);
                foreach (int idNum in seats)
                {

                    var basket = await _contextData.BasketTickets.AddAsync(new BasketTickets() { UserId = user.Id, BookedSeatId = idNum });//Include(x => x.Seats)

                }
                await _contextData.SaveChangesAsync();
                return "Ok";

            }
            return "NotOk";

        }

        //GET Buy/Booking
        public IActionResult Buy(string Id = null)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var performance = _contextData.Performance.FirstOrDefault(x => x.Id == Id);
           
            List<DateTime> availableDates = new List<DateTime>();
            var foundDates = _contextData.PerformanceDate.Where(x => x.PerformanceId == performance.Id).OrderBy(x => x.Date).ToList();
            //var foundDates = performance.PerformanceDate.OrderBy(x => x.Date).ToList();
            foreach(var date in foundDates)
            {
               availableDates.Add(date.Date);
            }

            //BookedSeats = seatsBooked, Costs = costs, Seats = _contextData.Seats.ToList()


            BuyTicket buyTicket = new BuyTicket() { PerformanceId = performance.Id, PerformanceName = performance.Name,
                LiveDates = new SelectList(availableDates),  AgeRestriction = performance.AgeRestriction,
                SelectedDate = availableDates.ElementAt(0), Description = performance.Description, Picture = performance.Picture,
                PriceBand = performance.PriceBand
                 
            };
            

            return View(buyTicket);
        }


        [HttpPost]
        public IActionResult Buy(string DateSelected = null, string Id = null)
        {

            if(Id == null)
            {
                return View();
            }
            List<string> parameters = new List<string>();
            parameters.Add(Id);
            if(DateSelected != null)
            {
                parameters.Add(DateSelected);
            }
            else
            {
                var perfDate = _contextData.PerformanceDate.Where(x => x.PerformanceId == Id).OrderBy(x => x.Date).ToList();
                parameters.Add(perfDate.ElementAt(0).Date.ToString());
            }

            return View("Seating", parameters);
            //return RedirectToAction(nameof(BookingController.Seating), "Booking", parameters);
            
            
        }

        [HttpGet]
        public async Task<IActionResult> BuyNow(string SavedSeats, int PerformanceDateId, decimal Total, string stripeToken, bool RememberMe)
        {
            List<int> seats = new List<int>();
            var user = await _userManager.GetUserAsync(User);
            if (SavedSeats != "" && Total > 0)
            {
                long amount = long.Parse(Total.ToString("#.00").Replace(".", ""));
                if (amount < 100)
                {
                    amount *= 100;
                }
                if (Charge(user.Email, stripeToken, amount, RememberMe))
                {   
                    
                    SavedSeats = SavedSeats.TrimEnd();
                    var receivedSeats = SavedSeats.Split(" ");
                    foreach (string el in receivedSeats)
                    {
                        seats.Add(int.Parse(el));
                    }
                    var perf = await _contextData.PerformanceDate.Include(x => x.Performance).Include(y => y.BookedSeats).FirstOrDefaultAsync(x => x.Id == PerformanceDateId);

                    List<string> rows = new List<string>();
                    List<int> chairNumbers = new List<int>();

                    foreach (int idNum in seats)
                    {

                        var bookedSeat = await _contextData.BookedSeats.FirstOrDefaultAsync(x => x.Id == idNum);
                        Seats selectedSeat = _contextData.Seats.Find(bookedSeat.Seatid);
                        bookedSeat.Booked = 2;
                        rows.Add(selectedSeat.RowName);
                        chairNumbers.Add(int.Parse(selectedSeat.ColumnNumber.Trim()));
                        _contextData.Update(bookedSeat);

                    }
                    await _contextData.SaveChangesAsync();
                    for (int i = 0; i < rows.Count(); i++)
                    {
                        int chairN = chairNumbers.ElementAt(i);

                        if (rows.ElementAt(i).Trim() == "A")
                        {
                            if (chairN > 6)
                            {
                                chairNumbers[i] = chairN - 6;
                            }
                        }
                        if (rows.ElementAt(i).Trim() == "B")
                        {
                            if (chairN < 17)
                            {
                                chairNumbers[i] = chairN - 12;
                            }
                            else
                            {
                                chairNumbers[i] = chairN - 16;
                            }
                        }
                        if (rows.ElementAt(i).Trim() == "C")
                        {
                            if (chairN == 19)
                            {
                                chairNumbers[i] = 1;
                            }
                            else if (chairN == 20)
                            {
                                chairNumbers[i] = 4;
                            }
                            else
                            {
                                chairNumbers[i] = chairN - 20;
                            }
                        }
                    }
                    TicketAndReceipt ticketAndReceipt = new TicketAndReceipt()
                    {
                        Date = perf.Date,
                        PerformanceName = perf.Performance.Name,
                        TotalCost = Total,
                        PersonName = _userManager.GetUserName(User),
                        ChairNumber = chairNumbers,
                        Rows = rows

                    };

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
            List<string> parames = new List<string>();
            parames.Add(Id);
            parames.Add(DateSelected);

            

            var perfDate = _contextData.PerformanceDate.Include(x => x.Performance).Include(x => x.BookedSeats).FirstOrDefault(x => x.Date == DateTime.Parse(parames.ElementAt(1)));
            

            IQueryable<string> rowNames = from r in _contextData.Seats
                                          orderby r.RowName
                                          select r.RowName;
            List<string> rows = await rowNames.Distinct().ToListAsync();
            for(int i = 0; i< rows.Count; i++)
            {
                rows[i] = rows.ElementAt(i).Trim();
            }
            
            bool discount = false;
            DateTime time = DateTime.Now;
            if(((int) time.DayOfWeek < 5) && ((int)time.DayOfWeek > 0))
            {
                discount = true;
                
            }
            decimal endPrice = 0;
            decimal startPrice = 0;
            string[] splitPrices = perfDate.Performance.PriceBand.Split("-");
            startPrice = decimal.Parse(splitPrices[0]);
            endPrice = decimal.Parse(splitPrices[1]);

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

            OldBuyTicket newTicket = new OldBuyTicket()
            {
                PerformanceName = perfDate.Performance.Name,
                SelectedDate = DateTime.Parse(parames.ElementAt(1)),
                BookedSeats = perfDate.BookedSeats.ToList(),
                RowNames = rows,
                Costs = costs,
                PerformanceDateId = perfDate.Id,
                DiscountApplied = discount,
                DiscountedPrices = startPrice + "-" + endPrice,
                PriceBand = perfDate.Performance.PriceBand,
                Total = 0,
                SavedSeats = "",
                UserEmail = user.Email,
                RememberMe = false
            };

            return View(newTicket);
        }

        [HttpGet]
        public IActionResult GiveTicketAndReceipt()
        {

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ReserveSeat(int id, int perfDateId) 
        {
            var seat = await _contextData.BookedSeats.FirstOrDefaultAsync(x => x.Id == id);
            if(seat.Booked != 2)
            {

                seat.ExpiryTime = DateTime.Now.AddMinutes(5);
                seat.Booked = 1;
                try
                {
                    _contextData.Update(seat);
                    await _contextData.SaveChangesAsync();
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

            
           
            if(RememberMe)
            {
                var user = _contextData.AspNetUsers.Include(x => x.Account).FirstOrDefault(x => x.Email == stripeEmail);
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
                    user.Account.CustomerId = customer.Id;
                    _contextData.SaveChanges();
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _contextData.BasketTickets.FirstOrDefaultAsync(m => m.BookedSeatId == id);
            _contextData.BasketTickets.Remove(ticket);
            await _contextData.SaveChangesAsync();
            return RedirectToAction(nameof(Basket));
        }
    }
}