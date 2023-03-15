using Abp.Application.Services.Dto;
using LibraryTask.BookCategories.Dto;
using LibraryTask.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Blog Category Details Dto
    /// </summary>
    public class BookDetailsDto: EntityDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        public List<BookTranslationDto> Translations { get; set; }
        public LiteAttachmentDto Attachment { get; set; }
        public UserDto Author { get; set; }
        public LiteBookCategoryDto BookCategory { get; set; }
    }
}
