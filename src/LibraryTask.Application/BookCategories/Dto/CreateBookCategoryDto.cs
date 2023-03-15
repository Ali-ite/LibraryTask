using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Create Blog Category Dto
    /// </summary>
    public class CreateBookCategoryDto
    {
        public bool IsParent { get; set; }

        public int? ParentCaregoryId { get; set; }
        public List<BookCategoryTranslationDto> Translations { get; set; }
      
    }
}
