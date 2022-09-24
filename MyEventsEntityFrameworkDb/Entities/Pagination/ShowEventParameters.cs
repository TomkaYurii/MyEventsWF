

using Entities.Pagination;

namespace MyEventsEntityFrameworkDb.Entities.Pagination
{
    public class ShowEventParameters : QueryStringParameters
    {
        public string? Name { get; set; }

    }
}
