using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRUdemy.Data;
using SignalRUdemy.Hubs;
using SignalRUdemy.Models;
using System.Diagnostics;

namespace SignalRUdemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowHub> _deathlytHub;
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<OrderHub> _orderHub;

        public HomeController(
            ILogger<HomeController> logger, 
            IHubContext<DeathlyHallowHub> deathlytHub,
            ApplicationDbContext context,
            IHubContext<OrderHub> orderHub
        )
        {
            _logger = logger;
            _deathlytHub = deathlytHub;
            _context = context;
            _orderHub = orderHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallow(string type)
        {
            if (SD.DealthyHalloRace.ContainsKey(type))
            {
                SD.DealthyHalloRace[type]++;
            }
            await _deathlytHub.Clients.All.SendAsync("updateDeathlyHallowCount",
                SD.DealthyHalloRace[SD.Cloak],
                SD.DealthyHalloRace[SD.Stone],
                SD.DealthyHalloRace[SD.Wand]);

            return Accepted();
        }

        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult DeathlyHallowRace()
        {
            return View();
        }
        public IActionResult HarryPotterHouse()
        {
            return View();
        }
        public IActionResult BasicChat()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ActionName("Order")]
        public async Task<IActionResult> Order()
        {
            string[] name = { "Bhrugen", "Ben", "Jess", "Laura", "Ron" };
            string[] itemName = { "Food1", "Food2", "Food3", "Food4", "Food5" };

            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(name.Length);

            Order order = new Order()
            {
                Name = name[index],
                ItemName = itemName[index],
                Count = index
            };

            return View(order);
        }

        [ActionName("Order")]
        [HttpPost]
        public async Task<IActionResult> OrderPost(Order order)
        {

            _context.Orders.Add(order);
            _context.SaveChanges();
            await _orderHub.Clients.All.SendAsync("createOrder");
            return RedirectToAction(nameof(Order));
        }
        [ActionName("OrderList")]
        public async Task<IActionResult> OrderList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var productList = _context.Orders.ToList();
            return Json(new { data = productList });
        }

    }
}