using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class RoomProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; }    
    }
}
