using Microsoft.AspNetCore.Mvc;
using PartyInviter.Models;
using System.Diagnostics;

namespace PartyInviter.Controllers
{
    public class HomeController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();  
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // TODO: store response from guest
            return View();
        }
        
        public ViewResult Thanks(GuestResponse guestResponse)
        {
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        public ViewResult ListResponses(GuestResponse guestResponse)
        {
            Repository.AddResponse(guestResponse);
            return View("ListResponses", guestResponse);
        }

        /*
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
    }