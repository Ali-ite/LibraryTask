using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryTask.Domain.BookCategories
{
    public class BookCategory : FullAuditedEntity, IMultiLingualEntity<BookCategoryTranslation>
    {
        public BookCategory()
        {

         
            Translations = new HashSet<BookCategoryTranslation>();

        }
        public bool IsParent  { get; set; }
     
        public int? ParentCaregoryId { get; set; }
        [ForeignKey(nameof(ParentCaregoryId))]
        public BookCategory Parentcategory { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BookCategoryTranslation> Translations { get; set; }

    }
    
}
