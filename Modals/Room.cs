namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateUser { get; set; } = "admin";
        public bool IsAvailable { get; set; } = true;
        public int RoomNumber { get; set; }

        public virtual Category Category { get; set; }  
        public virtual ICollection<RoomProperty> RoomProperties { get; set; }
    }
}
