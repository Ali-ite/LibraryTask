using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Update Blog Category Dto
    /// </summary>
    public class UpdateBookDto: CreateBookDto, IEntityDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }
    
    }
}
