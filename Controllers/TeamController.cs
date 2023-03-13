using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class TeamController : Controller
    {
        private IWebHostEnvironment hostEnvironemnt;
        private WebAppMVCLesson1DbContext db;
        public TeamController(WebAppMVCLesson1DbContext _db, IWebHostEnvironment _hostEnvironemnt)
        {
            db = _db;
            _hostEnvironemnt = _hostEnvironemnt;
        }
        public IActionResult Index()
        {
            var data = db.TeamWorks.ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult AddTeam(IFormFile Photo, Modals.TeamWork teamWork)
        {
            try
            {
                string shortpath = Path.Combine("img", "teams", Photo.FileName); ;
                string path = Path.Combine(hostEnvironemnt.WebRootPath, "img", "teams", Photo.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    Photo.CopyTo(stream);
                }
                teamWork.Photo = shortpath;

                db.TeamWorks.Add(teamWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "You did something wrong! -_-" + ex.Message + ex.InnerException.Message;
                return View(teamWork); 
            }
        }

        public IActionResult AddTeam()
        {
            Modals.TeamWork teamWork = new Modals.TeamWork();
            ViewBag.JobPositions = db.JobPositions.ToList();

            return View(teamWork);
        }
    }
}
