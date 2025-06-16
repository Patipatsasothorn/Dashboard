using System.Diagnostics;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _UserContext;

        public HomeController(ILogger<HomeController> logger, UserContext userContext)
        {
            _logger = logger;
            _UserContext = userContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult User(string Createdate)
        {
            if (string.IsNullOrEmpty(Createdate))
                return Json(new List<UserModel>());

            var dates = Createdate.Split('|');
            if (dates.Length != 2)
                return Json(new List<UserModel>());

            var startDate = dates[0];
            var endDate = dates[1];

            var query = _UserContext.UserModels
                        .FromSqlInterpolated($"EXEC Userdh {startDate}, {endDate}")
                        .ToList();

            return Json(query);
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
