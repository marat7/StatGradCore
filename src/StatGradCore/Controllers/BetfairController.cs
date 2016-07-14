using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using StatGradCore.Services;
using StatGradCore.Models;

namespace StatGradCore.Controllers
{
    
    public class BetfairController : Controller
    {

        IBetfairClient betfairClient;

        public BetfairController(IBetfairClient client)
        {
            betfairClient = client;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            return View(await betfairClient.Login(username, password));
        }

        public async Task<IActionResult> LoadEventTypes()
        {
            var marketFilter = new MarketFilter();
            var eventTypes = await betfairClient.listEventTypes(marketFilter);
            return View(eventTypes);
        }


        

        

        
    }
}