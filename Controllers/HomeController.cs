using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCLesson1.NewAdmin.Models;

namespace WebAppMVCLesson1.NewAdmin.Controllers
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
            try
            {
                string useremail = "bexultanov@icloud.com";
                DateTime dateTime = DateTime.Now;
                _logger.LogInformation("A user with email: {0} logged in {1}", useremail, dateTime);
                _logger.LogInformation("LogInformation");
                _logger.LogError("LogError");

                throw new Exception("test error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

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
    }
}