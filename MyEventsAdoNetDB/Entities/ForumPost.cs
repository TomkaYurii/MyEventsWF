using MyEventsAdoNetDB.Entities;

namespace Dapper_Example.DAL
{
    public class ForumPost : BaseEntity
    {
        public int User_Id { get; set; }
        public int Event_Id { get; set; }
        public string Message { get; set; }
    }
}
