namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class RoomProperty
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; }    
    }
}
