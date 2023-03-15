using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Domain.BookCategories;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Lite Blog Category Dto
    /// </summary>
    [AutoMap(typeof(BookCategory))]

    public class LiteBookCategoryDto: EntityDto<int>
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
      
    }
}
