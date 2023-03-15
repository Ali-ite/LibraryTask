using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Update Blog Category Dto
    /// </summary>
    public class UpdateBookCategoryDto: CreateBookCategoryDto, IEntityDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }
    
    }
}
