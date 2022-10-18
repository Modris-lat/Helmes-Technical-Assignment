using HelmesTechnicalAssignment.Models;
using HelmesTechnicalAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelmesTechnicalAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITerozaursService _terozaursService;

        public HomeController(ILogger<HomeController> logger, ITerozaursService terozaursService)
        {
            _logger = logger;
            _terozaursService = terozaursService;
        }
        public async Task<IActionResult> Index(string command, string input)
        {
            _logger.LogInformation($"Data request: {command}; Input: {input}");

            if (ValidateInput(command, input))
            {
                ViewBag.Result = await _terozaursService.AnalyzeAsync(input);
            }
            ViewBag.Input = input;

            return View();
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

        bool ValidateInput(string command, string word)
        {
            if (command != null && word != null && command == "GetData")
            {
                return true;
            }
            return false;
        }
    }
}