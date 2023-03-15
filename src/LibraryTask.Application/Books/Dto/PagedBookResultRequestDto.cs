using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Paged Blog Category Result Request Dto
    /// </summary>
    public class PagedBookResultRequestDto: PagedResultRequestDto
    {
        /// <summary>
        /// Keyword
        /// </summary>
        public string Keyword { get; set; }
        public int ? CategoryId { get; set; }
   

    }
}
