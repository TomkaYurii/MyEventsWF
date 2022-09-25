

using Entities.Pagination;

namespace MyEventsEntityFrameworkDb.Entities.Pagination
{
    public class ShowEventParameters : QueryStringParameters
    {
        public ShowEventParameters()
        {
            this.OrderBy = "DateOfEvent";

        }
        // поля для фільтрування даних
        public int MinYearOfEvent{ get; set; }
        public int MaxYearOfEvent { get; set; } = DateTime.Now.Year;
        public bool ValidYearRange => MaxYearOfEvent > MinYearOfEvent;

        // поля для пошуку попередньо відфільтрованих даних
        public string? Name { get; set; }
    }
}
