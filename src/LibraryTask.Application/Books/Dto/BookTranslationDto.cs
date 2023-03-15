using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask.Domain.Books;

namespace LibraryTask.Books.Dto
{
    /// <summary>
    /// Blog Category Translation Dto
    /// </summary>
    [AutoMap(typeof(BookTranslation))]
    public class BookTranslationDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        [Required]
        public string Language { get; set; }
    }
}
