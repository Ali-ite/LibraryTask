using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Domain.Books;
using LibraryTask.Users.Dto;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Lite Blog Category Dto
    /// </summary>
    [AutoMap(typeof(Book))]

    public class LiteBookDto: EntityDto<int>
    {
        /// <summary>
        /// Name
        /// </summary>
        public int NumberOfPages { get; set; }
        public UserDto Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        public LiteAttachmentDto Attachment { get; set; }
    }
}
