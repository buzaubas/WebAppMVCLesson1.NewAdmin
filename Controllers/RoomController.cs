using Microsoft.AspNetCore.Mvc;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class RoomController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment hostEnvironment;
        public RoomController(WebAppMVCLesson1DbContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }
    
        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();
            return View(rooms);
        }

        public IActionResult AddRoom(Room room)
        {
            if(room == null)
                room = new Room();
            ViewBag.CategoryList = db.Categories.ToList();

            return View(room);
        }

        [HttpPost]
        public IActionResult AddRoom(IFormFile MainPicturePath, Room room)
        {
            try
            {
                string shortpath = "";
                if(shortpath != null)
                {
                    shortpath = Path.Combine("img", "rooms", MainPicturePath.FileName); ;
                    string path = Path.Combine(hostEnvironment.WebRootPath, "img", "rooms", MainPicturePath.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        MainPicturePath.CopyTo(stream);
                    }
                }

                room.MainPicturePath = shortpath;
                room.CreateUser = "admin";
                room.CreateDate = DateTime.Now;

                if (room.RoomId == 0)
                {
                    db.Rooms.Add(room);
                }
                else
                {
                    var roomEdit = db.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
                    if (roomEdit == null)
                        throw new Exception("Room not found");
                    roomEdit.MainPicturePath = room.MainPicturePath;
                    roomEdit.RoomId = room.RoomId;
                    roomEdit.RoomNumber = room.RoomNumber;
                    roomEdit.Price = room.Price;
                    roomEdit.Category = room.Category;
                    roomEdit.Description = room.Description;
                    roomEdit.IsAvailable = room.IsAvailable;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(room);
            }
        }

        public IActionResult EditRoom(int Id)
        {

            var room = db.Rooms.FirstOrDefault(f=>f.RoomId == Id);
            return RedirectToAction("AddRoom", room);
        }
    }
}
