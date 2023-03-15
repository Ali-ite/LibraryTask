using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace LibraryTask.Domain.Books
{
    public class BookTranslation : FullAuditedEntity, IEntityTranslation<Book>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Book Core { get; set; }
        public int CoreId { get; set; }
        public string Language { get; set; }
    }
}