namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class CategoriesEvent
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? EventId { get; set; }

        public Category? Category { get; set; }
        public Event? Event { get; set; }
    }
}