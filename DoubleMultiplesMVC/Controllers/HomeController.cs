using DoubleMultiplesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoubleMultiplesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DMPage()
        {
            DoubleMultiple model = new();

            model.DoubleValue = 3;
            model.MultipleValue = 5;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DMPage(DoubleMultiple doublemultiple)
        {
            List<string> dmItems = new();

            bool doubleval;
            bool multipleval;

            for (int i = 1; i <= 100; i++)
            {
                doubleval = (i % doublemultiple.DoubleValue == 0);
                multipleval = (i % doublemultiple.MultipleValue == 0);

                if (doubleval == true && multipleval == true)
                {
                    dmItems.Add("Double Multiple");
                }
                else if (doubleval == true)
                {
                    dmItems.Add("Double");
                }
                else if (multipleval == true)
                {
                    dmItems.Add("Multiple");
                } else
                {
                    dmItems.Add(i.ToString());
                }
            }

            doublemultiple.Result = dmItems;

            return View(doublemultiple);
        }

        public IActionResult Privacy()
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