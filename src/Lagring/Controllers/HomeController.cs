using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Lagring.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            string key = "?key=AIzaSyD95JMZpTCtvVMiFY6142LilwZ4eLh_3Vo";
            ViewData["Message"] = "Your application description page.";

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.googleapis.com/drive/v3/files"+key)
            };

            var response = await client.GetAsync("");
            var result = await response.Content.ReadAsStringAsync();
            ViewData["files"] = result;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
