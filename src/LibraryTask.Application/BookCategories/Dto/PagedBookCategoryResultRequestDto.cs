using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Paged Blog Category Result Request Dto
    /// </summary>
    public class PagedBookCategoryResultRequestDto: PagedResultRequestDto
    {
        /// <summary>
        /// Keyword
        /// </summary>
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsParent { get; set; }
        public int? ParentCaregoryId { get; set; }

    }
}
