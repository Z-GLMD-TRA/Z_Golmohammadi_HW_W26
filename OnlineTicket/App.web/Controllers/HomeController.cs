using App.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Service.ServiceInterfaces;

namespace App.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var users = await _userService.GetAllUsers();
        //    return View(users);
        //}
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
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
