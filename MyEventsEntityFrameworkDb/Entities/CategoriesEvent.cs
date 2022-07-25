namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class CategoriesEvent
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? EventId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Event? Event { get; set; }
    }
}
