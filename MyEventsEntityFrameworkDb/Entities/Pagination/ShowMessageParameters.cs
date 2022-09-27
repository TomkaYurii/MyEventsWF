using Entities.Pagination;

namespace MyEventsEntityFrameworkDb.Entities.Pagination
{
    public class ShowMessageParameters : QueryStringParameters
    {
        public int? UserId { get; set; }
        public int? EventId { get; set; }
    }
}