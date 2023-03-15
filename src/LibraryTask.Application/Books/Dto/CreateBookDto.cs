using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Create Blog Category Dto
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// Translations
        /// </summary>
        public int NumberOfPages { get; set; }
        public int BookCategoryCaregoryId { get; set; }
        public long AuthorId { get; set; }
        public int AttachmentId { get; set; }
        public List<BookTranslationDto> Translations { get; set; }
      
    }
}
