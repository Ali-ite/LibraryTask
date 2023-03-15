using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LibraryTask.Authorization.Users;
using LibraryTask.Domain.BookCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Domain.Books
{
    public  class Book :FullAuditedEntity, IMultiLingualEntity<BookTranslation>
    {

        public int NumberOfPages { get; set; }
        public long  AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }
        public int BookCategoryCaregoryId { get; set; }
        [ForeignKey(nameof(BookCategoryCaregoryId))]
        public BookCategory BookCategory { get; set; }
        public ICollection<BookTranslation> Translations { get; set; }
    }
}
