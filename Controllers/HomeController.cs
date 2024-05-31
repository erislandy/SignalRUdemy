using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRUdemy.Hubs;
using SignalRUdemy.Models;
using System.Diagnostics;

namespace SignalRUdemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowHub> _deathlytHub;
        public HomeController(ILogger<HomeController> logger, IHubContext<DeathlyHallowHub> deathlytHub)
        {
            _logger = logger;
            _deathlytHub = deathlytHub;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}