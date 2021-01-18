using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Interfaces;
using SwapiMovies.Mvc.Models;

namespace SwapiMovies.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISwapiClientService _swapiClientService;
        private readonly IRatingService _ratingService;

        public HomeController(ILogger<HomeController> logger, ISwapiClientService swapiClientService, IRatingService ratingService)
        {
            _logger = logger;
            _swapiClientService = swapiClientService;
            _ratingService = ratingService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _swapiClientService.GetAll());
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _swapiClientService.GetDetails(Uri.UnescapeDataString(url)));
        }

        public IActionResult Rate(string url)
        {
            var ratingDto = new RatingDto {Url = Uri.UnescapeDataString(url)};
            
            return View(ratingDto);
        }

        [HttpPost]
        public IActionResult Rate(RatingDto ratingDto)
        {

            ratingDto.Url = Uri.UnescapeDataString(ratingDto.Url);
            if (ModelState.IsValid)
            {
                _ratingService.Add(ratingDto);
                return RedirectToAction(nameof(Success));
                
            }

            var errors = ModelState.Values.Select(v => v.Errors).ToList();

            return View(ratingDto);
        }
        
        public IActionResult Success()
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
