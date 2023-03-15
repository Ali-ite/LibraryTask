using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Blog Category Dto
    /// </summary>
    public class BookDto: EntityDto<int>
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
