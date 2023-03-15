using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Blog Category Details Dto
    /// </summary>
    public class BookCategoryDetailsDto: EntityDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        public List<BookCategoryTranslationDto> Translations { get; set; }
     
    }
}
