using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;


namespace LibraryTask.Domain.BookCategories
{
    public class BookCategoryTranslation : FullAuditedEntity, IEntityTranslation<BookCategory>
    {
        public string Name { get; set; }
        public BookCategory Core { get; set; }
        public int CoreId { get; set; }
        public string Language { get; set; }
    }
}