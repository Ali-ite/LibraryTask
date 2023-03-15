using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask.Domain.BookCategories;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Blog Category Translation Dto
    /// </summary>
    [AutoMap(typeof(BookCategoryTranslation))]
    public class BookCategoryTranslationDto
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
