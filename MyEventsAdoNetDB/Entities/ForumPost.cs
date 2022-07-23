namespace MyEventsAdoNetDB.Entities
{
    public class ForumPost : BaseEntity
    {
        public int User_Id { get; set; }
        public int Event_Id { get; set; }
        public string Message { get; set; }
    }
}
