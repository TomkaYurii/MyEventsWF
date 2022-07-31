using System;
using System.Collections.Generic;

namespace MyEventsEntityFrameworkDb.Entities
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? GalleryId { get; set; }
        public int? UserId { get; set; }
        public byte[]? ImageBytes { get; set; }

        public virtual Gallery? Gallery { get; set; }
        public virtual User? User { get; set; }
    }
}
